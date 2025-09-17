using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rando
{
    public partial class Rando : Form
    {
        private List<Trackpoint> _track = new();
        private List<Point> _screenPoints = new();
        private List<Color> _segmentColors = new();
        private readonly Color[] _gradient = new Color[]
        {
            Color.FromArgb(255, 144, 238, 144), // Vert Clair = 0
            Color.FromArgb(255, 162, 216, 128),
            Color.FromArgb(255, 180, 194, 112),
            Color.FromArgb(255, 198, 172,  96),
            Color.FromArgb(255, 216, 150,  80),
            Color.FromArgb(255, 234, 128,  64),
            Color.FromArgb(255, 244, 106,  48),
            Color.FromArgb(255, 248,  84,  36),
            Color.FromArgb(255, 252,  62,  24),
            Color.FromArgb(255, 254,  48,  18),
            Color.FromArgb(255, 255,  32,  12),
            Color.FromArgb(255, 255,  16,   6),
            Color.FromArgb(255, 255,   0,   0)  // Rouge vif = 12
        };

        private Button _btnLoad, _btnSave, _btnMerge;

        public Rando()
        {
            InitializeComponent();
            BuildUi();
            //DoubleBuffered = true;
        }

        private void BuildUi()
        {
            _btnLoad = new Button { Text = "Load GPX", AutoSize = true, Location = new Point(10, 10) };
            _btnSave = new Button { Text = "Save GPX", AutoSize = true, Location = new Point(110, 10) };
            _btnMerge = new Button { Text = "Merge GPX…", AutoSize = true, Location = new Point(210, 10) };

            _btnLoad.Click += (s, e) =>
            {
                using var ofd = new OpenFileDialog
                {
                    Filter = "GPX files (*.gpx)|*.gpx",
                    Title = "Open GPX"
                };
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    _track = ReadGpx(ofd.FileName);
                    RecomputeForDrawing();
                    Invalidate();
                }
            };

            _btnSave.Click += (s, e) =>
            {
                if (_track.Count == 0)
                {
                    MessageBox.Show("No track loaded.", "Save GPX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "GPX files (*.gpx)|*.gpx",
                    Title = "Save GPX",
                    FileName = "track.gpx"
                };
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    WriteGpx(sfd.FileName, _track);
                    MessageBox.Show("Saved.", "Save GPX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            //Concaténer
            

            Controls.Add(_btnLoad);
            Controls.Add(_btnSave);
            //Controls.Add(_btnMerge);
        }

        private void RecomputeForDrawing()
        {
            if (_track.Count < 2)
            {
                _screenPoints = new();
                _segmentColors = new();
                return;
            }

            _screenPoints = ToScreenPoints(_track, ClientRectangle, padding: 40);
            _segmentColors = ColorsByAltitude(_track);
        }

        private List<Color> ColorsByAltitude(List<Trackpoint> tps)
        {
            // Map altitude hundreds to gradient range [0..12] using min/max normalization
            var hundreds = tps.Select(tp => (int)Math.Floor(tp.Elevation / 100.0)).ToList();
            int minH = hundreds.Min();
            int maxH = hundreds.Max();
            int span = Math.Max(1, maxH - minH);

            return hundreds.Select(h =>
            {
                int idx = (int)Math.Round((double)(h - minH) * (_gradient.Length - 1) / span);
                idx = Math.Max(0, Math.Min(idx, _gradient.Length - 1));
                return _gradient[idx];
            }).ToList();
        }

        private List<Point> ToScreenPoints(List<Trackpoint> tps, Rectangle area, int padding)
        {
            double minLat = tps.Min(p => p.Latitude);
            double maxLat = tps.Max(p => p.Latitude);
            double minLon = tps.Min(p => p.Longitude);
            double maxLon = tps.Max(p => p.Longitude);

            // maintain aspect ratio inside padded rect
            int width = Math.Max(1, area.Width - 2 * padding);
            int height = Math.Max(1, area.Height - 2 * padding);

            double latSpan = Math.Max(1e-9, maxLat - minLat);
            double lonSpan = Math.Max(1e-9, maxLon - minLon);

            // Simple linear normalization; Y is inverted because screen Y grows downward
            return tps.Select(tp =>
            {
                double x01 = (tp.Longitude - minLon) / lonSpan;
                double y01 = (tp.Latitude - minLat) / latSpan;

                int x = area.Left + padding + (int)Math.Round(x01 * width);
                int y = area.Top + padding + (int)Math.Round((1 - y01) * height);
                return new Point(x, y);
            }).ToList();
        }

        

        private List<Trackpoint> ReadGpx(string path)
        {
            // Basic GPX reader (supports typical <trk><trkseg><trkpt> with <ele> and optional <time>)
            XDocument doc = XDocument.Load(path);
            XNamespace ns = doc.Root!.Name.Namespace;

            var q =
                from trk in doc.Descendants(ns + "trk")
                from seg in trk.Descendants(ns + "trkseg")
                from pt in seg.Descendants(ns + "trkpt")
                select new Trackpoint
                {
                    Latitude = double.Parse(pt.Attribute("lat")!.Value, CultureInfo.InvariantCulture),
                    Longitude = double.Parse(pt.Attribute("lon")!.Value, CultureInfo.InvariantCulture),
                    Elevation = TryParseDouble(pt.Element(ns + "ele")?.Value) ?? 0,
                    Time = TryParseTime(pt.Element(ns + "time")?.Value)
                };

            return q.ToList();

            static double? TryParseDouble(string? s)
                => double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : null;

            static DateTime? TryParseTime(string? s)
                => DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var t) ? t : null;
        }

        private void WriteGpx(string path, List<Trackpoint> tps)
        {
            XNamespace ns = "http://www.topografix.com/GPX/1/1";
            var gpx =
                new XElement(ns + "gpx",
                    new XAttribute("creator", "Rando WinForms"),
                    new XAttribute("version", "1.1"),
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(XName.Get("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance"),
                        "http://www.topografix.com/GPX/1/1/gpx.xsd"),
                    new XElement(ns + "trk",
                        new XElement(ns + "name", "Track"),
                        new XElement(ns + "trkseg",
                            tps.Select(tp =>
                                new XElement(ns + "trkpt",
                                    new XAttribute("lat", tp.Latitude.ToString("F6", CultureInfo.InvariantCulture)),
                                    new XAttribute("lon", tp.Longitude.ToString("F6", CultureInfo.InvariantCulture)),
                                    new XElement(ns + "ele", tp.Elevation.ToString("F1", CultureInfo.InvariantCulture)),
                                    tp.Time.HasValue ? new XElement(ns + "time", tp.Time.Value.ToUniversalTime().ToString("o")) : null
                                )
                            )
                        )
                    )
                );

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            gpx.Save(path);
        }

        private void Rando_Form_Paint(object? sender, PaintEventArgs e)
        {
            // Si rien ne s'affiche créer un chemin de base
            if (_track.Count < 2 || _screenPoints.Count < 2)
            {
                using var pen = new Pen(Color.Red, 2);
                Point[] sample = new[]
                {
                    new Point(30, 50), new Point(50, 10), new Point(80, 50), new Point(111, 400)
                };
                e.Graphics.DrawLines(pen, sample);
                return;
            }

            // Dessine les parties rouges
            for (int i = 0; i < _screenPoints.Count - 1; i++)
            {
                using var pen = new Pen(_segmentColors[i], 2f);
                e.Graphics.DrawLine(pen, _screenPoints[i], _screenPoints[i + 1]);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_track.Count > 1)
            {
                RecomputeForDrawing();
                Invalidate();
            }
        }
    }
}

using System.Diagnostics;
using System.Xml;
using MKCoolsoft;

namespace Rando
{
    public partial class Rando : Form
    {
        List<Trackpoint> _trackpoints = new List<Trackpoint>();

        List<Point> points;

        public Rando()

        {

            InitializeComponent();

            _trackpoints = ReadGPX.ReadGpxFile("loechegemmi.gpx");
        }



        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
           

            float scale = 10000f; // à ajuster
            PointF[] points = _trackpoints
                .Select(tp => new PointF(
                    (float)(tp.Longitude * scale),
                    (float)(tp.Latitude * scale)))
                .ToArray();

            using (Pen myPen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawLines(myPen, points);
            }




            //Pen myPen = new Pen(Color.Red);
            //myPen.Width = 2;

            //Point[] points = new Point[4] { new Point(30,50), new Point(50,10), new Point(80,50), new Point(111,400) };
            //this.CreateGraphics().DrawLines(myPen, points);
        }
    }
}

using Rando;
using System;
using System.Collections.Generic;
using System.Xml;
class ReadGPX
{
    public static List<Trackpoint> ReadGpxFile(string filePath)
    {
        var trackpoints = new List<Trackpoint>();
        XmlDocument doc = new XmlDocument();
        doc.Load(filePath);

        XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
        ns.AddNamespace("default", "http://www.topografix.com/GPX/1/1");
        XmlNodeList nodes = doc.SelectNodes("//default:trkpt", ns);

        foreach (XmlNode node in nodes)
        {
            double lat = double.Parse(node.Attributes["lat"].Value);
            double lon = double.Parse(node.Attributes["lon"].Value);
            double ele = 0;

            
              //If ele, exists get it 
             
            var eleNode = node.SelectSingleNode("default:ele", ns);
            if (eleNode != null)
            {
                double.TryParse(eleNode.InnerText, out ele);
            }

            var trackpoint = new Trackpoint(lat, lon, ele);
            trackpoints.Add(trackpoint);
        }

        return trackpoints;
    }
}


/*
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using Rando;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rando
{
    internal class ReadGPX
    {
        public static List<Trackpoint> ReadGpxFile(string filePath)
        {
            XNamespace ns = "http://www.topografix.com/GPX/1/1";
            XDocument gpxDoc = XDocument.Load(filePath);

            return gpxDoc
            .Descendants(ns + "trkpt")
            .Select(trkpt => new Trackpoint(
                (double)trkpt.Attribute("lat"),
                (double)trkpt.Attribute("lon"),
                (double?)trkpt.Element(ns + "ele") ?? 0
            ))
            .ToList();
        }
    }
}*/
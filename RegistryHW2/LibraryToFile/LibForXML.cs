using System.Linq;
using System.Xml.Linq;

namespace LibraryToFile
{
    public class LibForXML
    {
        public void Load(ref string fontFamily, ref string foreColor, ref string backgroundColor, ref double fontSize)
        {
            XDocument doc = XDocument.Load(@"settings.xml");
            fontFamily = (string)doc.Descendants("FontFamily").First();
            foreColor = (string)doc.Descendants("ForeColor").First();
            backgroundColor = (string)doc.Descendants("BackgroundColor").First();
            fontSize = (double?)doc.Descendants("FontSize").First() ?? 20.0;
        }

        public void Save(string fontFamily, string foreColor, string backgroundColor, double fontSize)
        {
            XElement xml = new XElement("Params",
                new XElement("FontFamily", fontFamily),
                new XElement("ForeColor", foreColor),
                new XElement("BackgroundColor", backgroundColor),
                new XElement("FontSize", fontSize));
            xml.Save(@"settings.xml");
        }
    }
}







//public class Point
//{
//    public string X;
//    public string Y;
//}

//public class Curve
//{
//    public Point[] Points;
//}

//public class Sample
//{
//    private void DoReadWrite(string filename, Curve from, out Curve to)
//    {
//        XmlSerializer xs = new XmlSerializer(typeof(Curve));

//        // Запись
//        Stream writer = new FileStream(filename, FileMode.Create);
//        xs.Serialize(writer, from);
//        writer.Close();

//        // Чтение        
//        Stream reader = new FileStream(filename, FileMode.Open);
//        to = (Curve)xs.Deserialize(reader);
//        reader.Close();
//    }
//}
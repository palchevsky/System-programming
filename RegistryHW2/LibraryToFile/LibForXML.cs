using System.Linq;
using System.Xml.Linq;

namespace LibraryToFile
{
    public class LibForXML
    {
        private string _fontFamily;
        public string FontFamily
        {
            get
            {
                return _fontFamily;
            }
            set { _fontFamily = value; }
        }

        private string _foreColor;

        public string ForeColor
        {
            get
            {
                return _foreColor;
            }
            set { _foreColor = value; }
        }

        private string _backgroundColor;
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set { _backgroundColor = value; }
        }

        private double _fontSize;
        public double FontSize
        {
            get
            {
                return _fontSize;
            }
            set { _fontSize = value; }
        }

        public void Load()
        {
            XDocument doc = XDocument.Load(@"settings.xml");
            _fontFamily = (string)doc.Descendants("FontFamily").First();
            _foreColor = (string)doc.Descendants("ForeColor").First();
            _backgroundColor = (string)doc.Descendants("BackgroundColor").First();
            _fontSize = (double?)doc.Descendants("FontSize").First() ?? 20.0;
        }

        public void Save()
        {
            XElement xml = new XElement("Params",
                new XElement("FontFamily", FontFamily),
                new XElement("ForeColor", ForeColor),
                new XElement("BackgroundColor", BackgroundColor),
                new XElement("FontSize", FontSize));
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
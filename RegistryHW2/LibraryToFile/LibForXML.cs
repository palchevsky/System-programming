using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryToFile
{
    public class LibForXML : Param
    {
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

        public void Load()
        {
            //var doc = new XmlDocument();
            //doc.LoadXml(@"settings.xml");
            //var @params= doc["Params"];
            //foreach (var item in @params)
            //{
            //    Console.WriteLine(item);
            //    //FontFamily = item("FontFamily").Value;
            //    //ForeColor = item("ForeColor").Value;
            //    //BackgroundColor = item("BackgroundColor").Value;
            //    //FontSize = Convert.ToDouble(item["FontSize"].Value);
            //}

            //FontFamily = doc["FontFamily"].Value;
            //ForeColor = doc["ForeColor"].Value;
            //BackgroundColor = doc["BackgroundColor"].Value;
            //FontSize = Convert.ToDouble(doc["FontSize"].Value);


            //var tasks = doc["Tasks"];
            //Param test = new Param();

            XDocument doc = XDocument.Load(@"settings.xml");
            //XElement xml = XElement.Load(@"settings.xml");
            //FontFamily = xml.Element("FontFamily").Value;
            //ForeColor = xml.Element("ForeColor").Value;
            //BackgroundColor = xml.Element("BackgroundColor").Value;
            //FontSize = Convert.ToDouble(xml.Element("FontSize").Value);

            //IEnumerable<XElement> @params =
            //from el in xml.Elements("Params")
            //select el;
            //foreach (XElement el in @params)
            //{
            //    el.Element()
            //    Console.WriteLine(el);
            //}

            var query = from xElem in doc.Descendants("Params")
                        select new Param
                        {
                            FontFamily = (string)xElem.Element("FontFamily"),
                            ForeColor = (string)xElem.Element("ForeColor"),
                            BackgroundColor = (string)xElem.Element("BackgroundColor"),
                            FontSize = (double?)xElem.Element("FontSize") ?? 20.0
                        };
            //FontFamily=query[0]
            //this.Clear();
            //AddRange(query);
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
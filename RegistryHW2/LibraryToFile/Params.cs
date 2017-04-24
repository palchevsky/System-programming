using System.IO;
using System.Xml.Serialization;

namespace LibraryToFile
{
    public class Params
    {
        private static string _fontFamily;
        public static string FontFamily
        {
            get
            {
                if (_fontFamily == null)
                {
                    return "Arial";
                }
                else
                {
                    return _fontFamily;
                }
            }
            set { _fontFamily = value; }
        }

        private static string _foreColor;

        public static string ForeColor
        {
            get
            {
                if (_foreColor == null)
                {
                    return "Black";
                }
                else
                {
                    return _foreColor;
                }
            }
            set { _foreColor = value; }
        }

        private static string _backgroundColor;
        public static string BackgroundColor
        {
            get
            {
                if (_backgroundColor == null)
                {
                    return "White";
                }
                else
                {
                    return _backgroundColor;
                }
            }
            set { _backgroundColor = value; }
        }

        private static double _fontSize;
        public static double FontSize
        {
            get
            {
                if (_fontSize <= 0 && _fontSize >= 100)
                {
                    return 15;
                }
                else
                {
                    return _fontSize;
                }
            }
            set { _fontSize = value; }
        }

        public static void SaveToXml()
        {
            Params smt = new Params();
            // Insert code to set properties and fields of the object.
            XmlSerializer mySerializer = new XmlSerializer(typeof(Params));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter("params.xml");
            mySerializer.Serialize(myWriter, smt);// (myWriter, myObject);
            myWriter.Close();

        }

        public static void LoadFromXml()
        {
            //Params smt = new Params();
            //// Insert code to set properties and fields of the object.
            //XmlSerializer mySerializer = new XmlSerializer(typeof(Params));
            //// To write to a file, create a StreamWriter object.
            //StreamWriter myWriter = new StreamWriter("params.xml");
            //mySerializer.Serialize(myWriter, smt);// (myWriter, myObject);
            //myWriter.Close();




            Params myObject;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(Params));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream("params.xml", FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            myObject = (Params)mySerializer.Deserialize(myFileStream);
        }

    }
}
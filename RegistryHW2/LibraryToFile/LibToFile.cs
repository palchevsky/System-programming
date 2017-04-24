using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryToFile
{
    public class LibToFile
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
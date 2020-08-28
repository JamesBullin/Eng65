using System;
using System.IO;
using System.Xml;

namespace SerialisationApp
{
    public class XMLReadWrite
    {
        static string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
        public static void Main()
        {
            WriteXML();
            ReadXML();

            var stringXML = File.ReadAllText(_path);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(stringXML);
        }

        public class Book
        {
            public String Title { get; set; }
            public String Author { get; set; }

        }

        public static void WriteXML()
        {
            Book happyP = new Book()
            {
                Title = "How to be a Happy C# Programmer",
                Author = "Cathy French"
            };
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));


            System.IO.FileStream file = System.IO.File.Create(_path);

            writer.Serialize(file, happyP);
            file.Close();
        }

        public static void ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));
            //         var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.StreamReader file = new System.IO.StreamReader(
                _path);
            Book book = (Book)reader.Deserialize(file);
            file.Close();
            Console.WriteLine($"{book.Author} {book.Title}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp
{
    public class FileOperations
    {
        public static void Serialize(List<EllipseInfo> ellipses, string path)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EllipseInfo>));
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                try
                {
                    xmlFormat.Serialize(stream, ellipses);
                }
                catch (SerializationException e)
                {
                    MessageBox.Show("Failed to serialize. Reason: " + e.Message);

                }
            }
        }

        public static List<EllipseInfo> Deserialize(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EllipseInfo>));
            List<EllipseInfo> ellipses = new List<EllipseInfo>();
            using (Stream stream = File.OpenRead(fileName))
            {
                try
                {
                    ellipses = (List<EllipseInfo>)xmlFormat.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    MessageBox.Show("Failed to deserialize. Reason: " + e.Message);

                }
            }
            return ellipses;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp
{
    public class FileOperations
    {
        public static void Serialize(ObservableCollection<Ellipse> ellipses, string path)
        {
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Ellipse>));
                    xmlFormat.Serialize(stream, ellipses);
                }
            }
            catch (IOException exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        public static ObservableCollection<Ellipse> Deserialize(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(ObservableCollection<Ellipse>));
            ObservableCollection<Ellipse> ellipses = new ObservableCollection<Ellipse>();
            using (Stream stream = File.OpenRead(fileName))
            {
                ellipses = (ObservableCollection<Ellipse>)xmlFormat.Deserialize(stream);
            }
            return ellipses;
        }
        }
    }

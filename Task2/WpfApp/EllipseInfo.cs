using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp
{
    [Serializable]
    public class EllipseInfo
    {
        public EllipseInfo()
        {
            Shape = new Ellipse();
        }
        public Point TopLeft { get; set; }

        public string Name { get; set; }

        [XmlIgnore]
        public Ellipse Shape { get; set; }
            
        
    }
}

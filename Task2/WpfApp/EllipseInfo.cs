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

        private static Color FromBrush(Brush br)
        {
            byte a = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).A;
            byte g = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).G;
            byte r = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).R;
            byte b = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).B;
            return new Color { A = a, R = r, G = g, B = b };
        }

        public Color Stroke
        {
            get
            {
                return FromBrush(Shape.Stroke);
            }
            set
            {
                Shape.Stroke = new SolidColorBrush(value);
            }
        }

        public Color Fill
        {
            get
            {
                return FromBrush(Shape.Fill);
            }
            set
            {
                Shape.Fill = new SolidColorBrush(value);
            }
        }

        public double Width
        {
            get
            {
                return Shape.Width;
            }
            set
            {
                Shape.Width = value;
            }
        }

        public double Height
        {
            get
            {
                return Shape.Height;
            }
            set
            {
                Shape.Height = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace WpfApp
{
    public class EllipseInfo
    {
        private Point topLeft;
        private Point botRight;
        private string name;
        private Ellipse shape;

        public EllipseInfo()
        {
            shape = new Ellipse();
        }
        public Point TopLeft
        {
            get
            {
                return topLeft;
            }
            set
            {
                topLeft = value;
            }
        }
        public Point BotRight
        {
            get
            {
                return botRight;
            }
            set
            {
                botRight = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Ellipse Shape
        {
            get
            {
                return shape;
            }
            set
            {
                shape = value;
            }
        }
    }
}

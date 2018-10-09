using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp
{
    class EllipseInfo
    {
        private Point topLeft;
        private Point botRight;
        private string name;
        private Ellipse shape;
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
        public EllipseInfo Shape
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp
{
    public class EllipseListChangedEventArgs
    {
        public EllipseInfo Ellipse { get; set; }
        public EllipseCanvas Canvas { get; set; }

        public EllipseListChangedEventArgs(EllipseInfo ellipse, EllipseCanvas canvas)
        {
            Ellipse = ellipse;
            Canvas = canvas;
        }
    }
}

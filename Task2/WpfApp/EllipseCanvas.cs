using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp
{
    public class EllipseCanvas
    {
        private Canvas canvas = new Canvas();
        public Canvas Canvas
        {
            get
            {
                return this.canvas;
            }
            set
            {
                if(this.canvas != null)
                {
                    this.canvas.MouseLeftButtonDown -= canvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp -= canvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove -= canvasDrawingArea_MouseMove;
                }
                this.canvas = value;
                this.canvas.MouseLeftButtonDown += canvasDrawingArea_MouseLeftButtonDown;
                this.canvas.MouseLeftButtonUp += canvasDrawingArea_MouseLeftButtonUp;
                this.canvas.MouseMove += canvasDrawingArea_MouseMove;
            }
        }
        
        private List<EllipseInfo> ellipses = new List<EllipseInfo>();

        private Point a;
        private Point b;
        private Ellipse ellipseTemp;
        private bool isDraw = false;

        public EllipseCanvas()
        {
            ellipseTemp = new Ellipse();
            ellipseTemp.Stroke = Brushes.Green;
            ellipseTemp.StrokeThickness = 1.5;
        }

        public EllipseCanvas(Canvas canvas) : this()
        {
            Canvas = canvas;
        }

        private void OnEndCreation(MouseEventArgs e)
        {
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.Shape.Height = Math.Abs(a.Y - b.Y);
            ellipse.Shape.Width = Math.Abs(a.X - b.X);
            ellipse.Shape.Stroke = Brushes.Red;
            ellipse.Shape.StrokeThickness = 1.5;
            ellipse.Shape.Fill = Brushes.AliceBlue;
            Canvas.Children.Add(ellipse.Shape);
            ellipse.TopLeft = (new Point(a.X > b.X ? b.X : a.X, a.Y > b.Y ? b.Y : a.Y));
            Canvas.SetLeft(ellipse.Shape, ellipse.TopLeft.X);
            Canvas.SetTop(ellipse.Shape, ellipse.TopLeft.Y);
            Canvas.Children.Remove(ellipseTemp);
            ellipses.Add(ellipse);
            isDraw = false;
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            a = e.GetPosition(Canvas);
            ellipseTemp.Width = 0;
            ellipseTemp.Height = 0;
            Canvas.Children.Add(ellipseTemp);
            isDraw = true;
        }

        private void canvasDrawingArea_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnEndCreation(e);
        }

        private void canvasDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDraw)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    b = e.GetPosition(Canvas);
                    ellipseTemp.Height = Math.Abs(a.Y - b.Y);
                    ellipseTemp.Width = Math.Abs(a.X - b.X);
                    Canvas.SetLeft(ellipseTemp, a.X > b.X ? b.X : a.X);
                    Canvas.SetTop(ellipseTemp, a.Y > b.Y ? b.Y : a.Y);
                }
                else
                {
                    OnEndCreation(e);
                }
            }
        }

        public delegate void ListChangedEvent(object sender, EllipseListChangedEventArgs args);

        event ListChangedEvent OnEllipseAdded;
        event ListChangedEvent OnEllipseRemoved;

        public void AddEllipse(EllipseInfo ellipse)
        {
            this.ellipses.Add(ellipse);
            OnEllipseAdded(this, new EllipseListChangedEventArgs( ellipse, this ));
        }

        public void Clear()
        {
            foreach (EllipseInfo ellipse in ellipses)
            {
                OnEllipseRemoved(this, new EllipseListChangedEventArgs(ellipse, this));
            }
            ellipses.Clear();
        }

        public void RemoveEllipse(EllipseInfo ellipse)
        {
            ellipses.Remove(ellipse);
            OnEllipseRemoved(this, new EllipseListChangedEventArgs(ellipse, this));
        }
    }
}

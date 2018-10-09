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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<EllipseInfo> ellipses = new List<EllipseInfo>();

        private Point a;
        private Point b;
        private Ellipse ellipseTemp;
        private bool isDraw = false;

        /// <summary>
        /// Initialize main window and components
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            ellipseTemp = new Ellipse();
            ellipseTemp.Stroke = Brushes.Green;
            ellipseTemp.StrokeThickness = 1.5;
        }

        private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            a=e.GetPosition(canvasDrawingArea);
            ellipseTemp.Width = 0;
            ellipseTemp.Height = 0;
            canvasDrawingArea.Children.Add(ellipseTemp);
            isDraw = true;
        }

        private void canvasDrawingArea_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            b = e.GetPosition(canvasDrawingArea);
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.Shape.Height=Math.Abs(a.Y-b.Y);
            ellipse.Shape.Width = Math.Abs(a.X-b.X);
            ellipse.Shape.Stroke = Brushes.Red;
            ellipse.Shape.StrokeThickness=1.5;
            ellipse.Shape.Fill = Brushes.AliceBlue;
            canvasDrawingArea.Children.Add(ellipse.Shape);
            ellipse.TopLeft = (new Point(a.X > b.X ? b.X : a.X, a.Y > b.Y ? b.Y : a.Y));
            Canvas.SetLeft(ellipse.Shape, ellipse.TopLeft.X);
            Canvas.SetTop(ellipse.Shape, ellipse.TopLeft.Y);
            canvasDrawingArea.Children.Remove(ellipseTemp);
            ellipses.Add(ellipse);
            isDraw = false;
        }

        private void canvasDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isDraw)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    b = e.GetPosition(canvasDrawingArea);
                    ellipseTemp.Height = Math.Abs(a.Y - b.Y);
                    ellipseTemp.Width = Math.Abs(a.X - b.X);
                    Canvas.SetLeft(ellipseTemp, a.X > b.X ? b.X : a.X);
                    Canvas.SetTop(ellipseTemp, a.Y > b.Y ? b.Y : a.Y);
                }
                else
                {
                    EllipseInfo ellipse = new EllipseInfo();
                    ellipse.Shape.Height = ellipseTemp.Height;
                    ellipse.Shape.Width = ellipseTemp.Width;
                    ellipse.Shape.Stroke = Brushes.Red;
                    ellipse.Shape.StrokeThickness = 1.5;
                    ellipse.Shape.Fill = Brushes.AliceBlue;
                    canvasDrawingArea.Children.Add(ellipse.Shape);
                    ellipse.TopLeft= (new Point(a.X > b.X ? b.X : a.X, a.Y > b.Y ? b.Y : a.Y));
                    Canvas.SetLeft(ellipse.Shape, ellipse.TopLeft.X);
                    Canvas.SetTop(ellipse.Shape, ellipse.TopLeft.Y);
                    canvasDrawingArea.Children.Remove(ellipseTemp);
                    ellipses.Add(ellipse);
                    isDraw = false;
                }
            }
        }
    }
}

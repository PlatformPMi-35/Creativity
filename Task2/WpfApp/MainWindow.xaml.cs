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
        public List<Ellipse> ellipses = new List<Ellipse>();

        private Point a;
        private Point b;
        private Ellipse ellipseTemp;
        private bool isDraw = false;

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
            Ellipse ellipse = new Ellipse();
            ellipse.Height=Math.Abs(a.Y-b.Y);
            ellipse.Width = Math.Abs(a.X-b.X);
            ellipse.Stroke = Brushes.Red;
            ellipse.StrokeThickness=1.5;
            ellipse.Fill = Brushes.AliceBlue;
            canvasDrawingArea.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, a.X > b.X ? b.X : a.X);
            Canvas.SetTop(ellipse, a.Y > b.Y ? b.Y : a.Y);
            canvasDrawingArea.Children.Remove(ellipseTemp);
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
                    Ellipse ellipse = new Ellipse();
                    ellipse.Height = ellipseTemp.Height;
                    ellipse.Width = ellipseTemp.Width;
                    ellipse.Stroke = Brushes.Red;
                    ellipse.StrokeThickness = 1.5;
                    ellipse.Fill = Brushes.AliceBlue;
                    canvasDrawingArea.Children.Add(ellipse);
                    Canvas.SetLeft(ellipse, a.X > b.X ? b.X : a.X);
                    Canvas.SetTop(ellipse, a.Y > b.Y ? b.Y : a.Y);
                    canvasDrawingArea.Children.Remove(ellipseTemp);
                    isDraw = false;
                }
            }
        }
    }
}

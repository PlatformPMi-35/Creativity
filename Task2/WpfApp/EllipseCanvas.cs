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
using System.Diagnostics;

using System.Collections.ObjectModel;
using System.Collections.Specialized;

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
                if (this.canvas != null)
                {
                    this.canvas.MouseLeftButtonDown -= canvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp -= canvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove -= canvasDrawingArea_MouseMove;
                }
                this.canvas = value;
                if (this.canvas != null)
                {
                    this.canvas.MouseLeftButtonDown += canvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp += canvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove += canvasDrawingArea_MouseMove;
                }
            }
        }

        private List<EllipseInfo> ellipses = new List<EllipseInfo>();
        public List<EllipseInfo> Ellipses
        {
            get
            {
                return ellipses;
            }
        }

        private EllipseInfo currentEllipse;
        public EllipseInfo CurrentEllipse
        {
            get
            {
                return currentEllipse;
            }
            set
            {
                if (currentEllipse != null)
                {
                    currentEllipse.Shape.StrokeThickness = 1.5;
                    Canvas.SetZIndex(currentEllipse.Shape, 0);
                    currentEllipse.Shape.MouseLeftButtonDown -= Shape_MouseLeftButtonDown;
                    currentEllipse.Shape.MouseLeftButtonUp -= Shape_MouseLeftButtonUp;
                    currentEllipse.Shape.MouseMove -= Shape_MouseMove;
                    currentEllipse.Shape.KeyDown -= Ellipse_KeyDown;
                    currentEllipse.Shape.Focusable = false;
                }
                else
                {
                    this.canvas.MouseLeftButtonDown -= canvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp -= canvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove -= canvasDrawingArea_MouseMove;
                }
                currentEllipse = value;
                if (currentEllipse != null)
                {
                    currentEllipse.Shape.StrokeThickness = 3;
                    currentEllipse.Shape.MouseLeftButtonDown += Shape_MouseLeftButtonDown;
                    currentEllipse.Shape.MouseLeftButtonUp += Shape_MouseLeftButtonUp;
                    currentEllipse.Shape.MouseMove += Shape_MouseMove;
                    currentEllipse.Shape.KeyDown += Ellipse_KeyDown;
                    Canvas.SetZIndex(currentEllipse.Shape, 1);
                    currentEllipse.Shape.Focusable = true;
                    Keyboard.ClearFocus();
                    Keyboard.Focus(currentEllipse.Shape);
                }
                else
                {
                    this.canvas.MouseLeftButtonDown += canvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp += canvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove += canvasDrawingArea_MouseMove;
                }
            }
        }


        private void MoveEllipse(EllipseInfo ellipse, Point shift)
        {
            ellipse.TopLeft = new Point(ellipse.TopLeft.X + shift.X, ellipse.TopLeft.Y + shift.Y);
            Canvas.SetTop(ellipse.Shape, ellipse.TopLeft.Y);
            Canvas.SetLeft(ellipse.Shape, ellipse.TopLeft.X);
        }

        private void Ellipse_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.ClearFocus();
            Key k = e.Key;
            switch (k)
            {
                case Key.Down:
                    {
                        MoveEllipse(currentEllipse, new Point(0.0, 1));
                        break;
                    }
                case Key.Up:
                    {
                        MoveEllipse(currentEllipse, new Point(0.0, -1));
                        break;
                    }
                case Key.Left:
                    {
                        MoveEllipse(currentEllipse, new Point(-1, 0.0));
                        break;
                    }
                case Key.Right:
                    {
                        MoveEllipse(currentEllipse, new Point(1, 0.0));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            e.Handled = true;
            Keyboard.Focus(currentEllipse.Shape);
        }

        private void Shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDraw = false;
        }

        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                b = e.GetPosition(Canvas);
                currentEllipse.TopLeft += b - a;
                a = b;
                Canvas.SetTop(currentEllipse.Shape, currentEllipse.TopLeft.Y);
                Canvas.SetLeft(currentEllipse.Shape, currentEllipse.TopLeft.X);
            }
        }

        private void Shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            a = e.GetPosition(Canvas);
            isDraw = true;
        }

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
            SetTextColorDialog dialog = new SetTextColorDialog();
            Window window = new Window
            {
                Title = "Name and color",
                Content = dialog,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            if (
            window.ShowDialog() == true)
            {
                EllipseInfo ellipse = new EllipseInfo();
                ellipse.Shape.Height = Math.Abs(a.Y - b.Y);
                ellipse.Shape.Width = Math.Abs(a.X - b.X);
                ellipse.Shape.Stroke = dialog.Contour;
                ellipse.Shape.StrokeThickness = 1.5;
                ellipse.Shape.Fill = dialog.Fill;
                ellipse.Name = dialog.NameItem;
                ellipse.TopLeft = (new Point(a.X > b.X ? b.X : a.X, a.Y > b.Y ? b.Y : a.Y));
                AddEllipse(ellipse);
            }
            Canvas.Children.Remove(ellipseTemp);
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

        public event ListChangedEvent OnEllipseAdded;

        public event ListChangedEvent OnEllipseRemoved;

        public void AddEllipse(EllipseInfo ellipse)
        {
            this.ellipses.Add(ellipse);
            Canvas.SetZIndex(ellipse.Shape, 0);
            Canvas.SetLeft(ellipse.Shape, ellipse.TopLeft.X);
            Canvas.SetTop(ellipse.Shape, ellipse.TopLeft.Y);
            this.Canvas.Children.Add(ellipse.Shape);
            OnEllipseAdded?.Invoke(this, new EllipseListChangedEventArgs(ellipse, this));
        }

        public void Clear()
        {
            foreach (EllipseInfo ellipse in ellipses)
            {
                OnEllipseRemoved?.Invoke(this, new EllipseListChangedEventArgs(ellipse, this));
            }
            currentEllipse = null;
            ellipses.Clear();
            Canvas.Children.Clear();
        }

        public void RemoveEllipse(EllipseInfo ellipse)
        {
            ellipses.Remove(ellipse);
            if (ReferenceEquals(this.currentEllipse, ellipse))
            {
                currentEllipse = null;
            }
            Canvas.Children.Remove(ellipse.Shape);
            OnEllipseRemoved?.Invoke(this, new EllipseListChangedEventArgs(ellipse, this));
        }

        public bool IsEmpty()
        {
            return ellipses.Count == 0;
        }
    }
}

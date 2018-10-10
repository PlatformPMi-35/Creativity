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
        EllipseCanvas ellipseCanvas = new EllipseCanvas();

        /// <summary>
        /// Initialize main window and components
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ellipseCanvas.Canvas = canvasDrawingArea;
            ellipseCanvas.OnEllipseAdded += EllipseCanvas_OnEllipseAdded;
        }

        private ICommand newFile;
        private ICommand openFile;
        private ICommand saveFile;

        void ResetCurrentEllipse()
        {
            this.ellipseCanvas.CurrentEllipse = null;
        }
        private ICommand resetEllipse;

        public ICommand ResetEllipse
        {
            get
            {
                return this.resetEllipse ?? (this.resetEllipse = new CommandHandler(() => ResetCurrentEllipse(), true));
            }
        }

        private void EllipseCanvas_OnEllipseAdded(object sender, EllipseListChangedEventArgs args)
        {
            ChooseEllipseCommand toadd = new ChooseEllipseCommand { Canvas = this.ellipseCanvas, Ellipse = args.Ellipse };
            menuShapes.Items.Add(toadd);
            menuContext.Items.Add(toadd);
        }
        private bool canExecute;
        public ICommand NewFile
        {
            get
            {
                return this.newFile ?? (this.newFile = new CommandHandler(() => NewFileExecute(), this.canExecute));
            }
        }

        public ICommand OpenFile
        {
            get
            {
                return this.openFile ?? (this.openFile = new CommandHandler(() => OpenFileExecute(), this.canExecute));
            }
        }

        public ICommand SaveFile
        {
            get
            {
                return this.saveFile ?? (this.saveFile = new CommandHandler(() => SaveFileExecute(), this.canExecute));
            }
        }

      //  public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            ////if (PropertyChanged != null)
            ////{
            ////    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            ////}
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void NewFileExecute()
        {
          //  this.canvasDrawingArea = new Canvas();
           // this.ellipses.Clear();
        }

        public void OpenFileExecute()
        {
            this.canvasDrawingArea = new Canvas();
          //  this.ellipses.Clear();
         //   OpenFileDialog dialog = new OpenFileDialog
        //    {
         //       Filter = "Xml files (*.xml)|*.xml"
        //    };
        //    if (dialog.ShowDialog() == true)
        //    {
       //         this.ellipses.Clear();
        //        this.ellipses = FileOperations.Deserialize(dialog.FileName);
        //    }
        }

        public void SaveFileExecute()
        {
            //try
            //{
            //    if (this.ellipses.Count == 0)
            //    {
            //        throw new ArgumentNullException("There aren't shapes on the drawing area");
            //    }
            //    SaveFileDialog dialog = new SaveFileDialog
            //    {
            //        Filter = "Xml files (*.xml)|*.xml"
            //    };
            //    if (dialog.ShowDialog() == true)
            //    {
            //        FileOperations.Serialize(this.ellipses, dialog.FileName);
            //    }
            //}
            //catch (ArgumentNullException exp)
            //{
            //    MessageBox.Show(exp.ParamName);
            //}
        }


    }
}

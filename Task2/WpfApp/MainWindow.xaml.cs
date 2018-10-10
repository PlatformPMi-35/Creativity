//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using Microsoft.Win32;
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
        /// <summary>
        /// Drawing area
        /// </summary>
        private EllipseCanvas ellipseCanvas = new EllipseCanvas();

        /// <summary>
        /// Command to make a new file
        /// </summary>
        private ICommand newFile;

        /// <summary>
        /// Command to open file
        /// </summary>
        private ICommand openFile;

        /// <summary>
        /// Command to save file
        /// </summary>
        private ICommand saveFile;

        /// <summary>
        /// Command to reset ellipse
        /// </summary>
        private ICommand resetEllipse;

        /// <summary>
        /// bool value whether the command can execute
        /// </summary>
        private bool canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.ellipseCanvas.Canvas = this.canvasDrawingArea;
            this.ellipseCanvas.OnEllipseAdded += this.EllipseCanvas_OnEllipseAdded;
            this.canExecute = true;
        }

        /// <summary>
        /// Gets ressetEllipse command
        /// </summary>
        public ICommand ResetEllipse
        {
            get
            {
                return this.resetEllipse ?? (this.resetEllipse = new CommandHandler(() => this.ResetCurrentEllipse(), true));
            }
        }

        /// <summary>
        /// Gets NewFile Command
        /// </summary>
        public ICommand NewFile
        {
            get
            {
                return this.newFile ?? (this.newFile = new CommandHandler(() => this.NewFileExecute(), this.canExecute));
            }
        }

        /// <summary>
        /// Gets OpenFile command
        /// </summary>
        public ICommand OpenFile
        {
            get
            {
                return this.openFile ?? (this.openFile = new CommandHandler(() => this.OpenFileExecute(), this.canExecute));
            }
        }

        /// <summary>
        /// Gets SaveFileCommand
        /// </summary>
        public ICommand SaveFile
        {
            get
            {
                return this.saveFile ?? (this.saveFile = new CommandHandler(() => this.SaveFileExecute(), this.canExecute));
            }
        }

        /// <summary>
        /// Clears drawing area, creates new file
        /// </summary>
        public void NewFileExecute()
        {
           // this.canvasDrawingArea = new Canvas();
           // this.ellipses.Clear();
        }

        /// <summary>
        /// Opens new file
        /// </summary>
        public void OpenFileExecute()
        {
            this.canvasDrawingArea = new Canvas();
            // this.ellipses.Clear();
            // OpenFileDialog dialog = new OpenFileDialog
            // {
            //     Filter = "Xml files (*.xml)|*.xml"
            // };
            // if (dialog.ShowDialog() == true)
            // {
            //     this.ellipses.Clear();
            //     this.ellipses = FileOperations.Deserialize(dialog.FileName);
            // }
        }

        /// <summary>
        /// Saves current ellipses
        /// </summary>
        public void SaveFileExecute()
        {
            try
            {
                if (this.ellipseCanvas.IsEmpty() == true)
                {
                    throw new ArgumentNullException("There aren't shapes on the drawing area");
                }

                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Xml files (*.xml)|*.xml"
                };
                if (dialog.ShowDialog() == true)
                {
                    FileOperations.Serialize(this.ellipseCanvas.Ellipses, dialog.FileName);
                }
            }
            catch (ArgumentNullException exp)
            {
                MessageBox.Show(exp.ParamName);
            }
        }

        /// <summary>
        /// Resets current ellipse
        /// </summary>
        private void ResetCurrentEllipse()
        {
            this.ellipseCanvas.CurrentEllipse = null;
        }

        /// <summary>
        /// Handles the OnEllipseAdded event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="args">Provides data for the EllipseListChangedEventArgs event</param>
        private void EllipseCanvas_OnEllipseAdded(object sender, EllipseListChangedEventArgs args)
        {
            ChooseEllipseCommand toadd = new ChooseEllipseCommand { Canvas = this.ellipseCanvas, Ellipse = args.Ellipse };
            menuShapes.Items.Add(toadd);
            menuContext.Items.Add(toadd);
        }
    }
}

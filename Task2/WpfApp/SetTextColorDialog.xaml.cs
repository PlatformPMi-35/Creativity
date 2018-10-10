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
    /// Interaction logic for SetTextColorDialog.xaml
    /// </summary>
    public partial class SetTextColorDialog : UserControl
    {
        private Brush contour;
        public Brush Contour {
            get
            {
                return contour;
            }

            set
            {
                contour = value;
            }
        }
        private Brush fill;
        public Brush Fill {
            get
            {
                return fill;
            }
            set
            {
                fill = value;
            }
        }
        public string NameItem { get; set; }
        public SetTextColorDialog()
        {
            InitializeComponent();
            NameItem = "item";
            txtName.Text = NameItem;
            Contour = Brushes.Black;
            btnContour.Background = Contour;
            Fill = Brushes.White;
            btnFill.Background = Fill;
        }

        private void btnContour_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dialog=new System.Windows.Forms.ColorDialog();
            if(dialog.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color a = dialog.Color;
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(a.A,a.R,a.G,a.B));
                Contour = brush;
                btnContour.Background = Contour;
            }
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color a = dialog.Color;
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(a.A, a.R, a.G, a.B));
                Fill = brush;
                btnFill.Background = Fill;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Window window = this.Parent as Window;
            if (window!=null)
            {
                NameItem = txtName.Text;
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}

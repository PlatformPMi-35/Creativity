using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IOrderConfiguration configuration;
        private IOrderFactory factory;
        private IOrderBuilder builder;
        private IOrderValidation validator;
        private IDatabaseFacade database;
        
        public MainWindow()
        {
            InitializeComponent();
            configuration = new OrderConfiguration();
            factory = configuration.GetFactory();
            builder = configuration.GetBuilder();
            validator = configuration.GetValidator();
            database = configuration.GetDatabase();
        }

        private void buttonMakeOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

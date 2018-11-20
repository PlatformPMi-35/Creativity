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
            builder.Factory =  factory;
            textBoxClassOfTheTaxi.ItemsSource = Enum.GetNames(typeof(CarClass));
            textBoxClassOfTheTaxi.SelectedIndex = 0;
        }
        
        private void buttonMakeOrder_Click(object sender, RoutedEventArgs e)
        {
            string message = " is not in correct format.";
            string caption = "Error Detected in Input";
            MessageBoxButton buttons = MessageBoxButton.OK;
            string arrivalStreet = comboBoxAddressOfArrivalStreet.Text;
            string arrivalHouse = textBoxAddressOfArrivalHouseNumber.Text;
            string arrivalPorch = textBoxAddressOfArrivalPorch.Text;
            string departureStreet = comboBoxAddressOfDepartureStreet.Text;
            string departureHouse = textBoxAddressOfDepartureHouseNumber.Text;
            string departurePorch = textBoxAddressOfDeparturePorch.Text;
            string name = textBoxNameOfClient.Text;
            string phone = textBoxPhoneNumber.Text;
            string time = textBoxTimeOfTheArrivalTaxi.Text;
            
            if(!validator.ValidateName(name)) 
            {
                MessageBox.Show("Name" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidatePhone(phone)) 
            {
                MessageBox.Show("Phone" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidateStreet(arrivalStreet)) 
            {
                MessageBox.Show("Street" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidateHouse(arrivalHouse)) 
            {
                MessageBox.Show("House" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidatePorch(arrivalPorch)) 
            {
                MessageBox.Show("Porch" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidateStreet(departureStreet)) 
            {
                MessageBox.Show("Street" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidateHouse(departureHouse)) 
            {
                MessageBox.Show("House" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidatePorch(departurePorch)) 
            {
                MessageBox.Show("Porch" + message, caption, buttons);
                return;
            }
            else if(!validator.ValidateTime(time))
            {
                MessageBox.Show("Time" + message, caption, buttons);
                return;
            }
            builder.SetName(name);
            builder.SetPhoneNumber(phone);
            builder.SetAddressOfDeparture($"{arrivalStreet};{arrivalHouse};{arrivalPorch}");
            builder.SetAddressOfArrival($"{departureStreet};{departureHouse};{departurePorch}");
            builder.SetTimeOfArrival(time);
            builder.SetClassOfTaxi(textBoxClassOfTheTaxi.Text);
            database.AddOrder(builder.Build());
            MessageBox.Show("Ваше замовлення успішно додано, за вами виїхали");
        }
    }
}

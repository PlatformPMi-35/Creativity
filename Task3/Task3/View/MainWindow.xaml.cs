//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
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
using Task3.Model;
using Task3.UnitOfWork;
namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Configuration for orders
        /// </summary>
        private IOrderConfiguration configuration;

        /// <summary>
        /// Factory for orders
        /// </summary>
        private IOrderFactory factory;

        /// <summary>
        /// Builder for orders
        /// </summary>
        private IOrderBuilder builder;

        /// <summary>
        /// Validator for orders
        /// </summary>
        private IOrderValidation validator;

        /// <summary>
        /// Database for orders
        /// </summary>
        private IDatabaseFacade database;

        /// <summary>
        /// Initializes a new instance of the <see cref = "MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.configuration = new OrderConfiguration();
            this.factory = configuration.GetFactory();
            this.builder = configuration.GetBuilder();
            this.validator = configuration.GetValidator();
            this.database = configuration.GetDatabase();
            this.builder.Factory =  factory;
            this.textBoxClassOfTheTaxi.ItemsSource = Enum.GetNames(typeof(CarClass));
            this.textBoxClassOfTheTaxi.SelectedIndex = 0;
        }

        /// <summary>
        /// Save inputed order
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">routed events args</param>
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

            if (!this.validator.ValidateName(name))
            {
                MessageBox.Show("Name" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidatePhone(phone))
            {
                MessageBox.Show("Phone" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidateStreet(arrivalStreet))
            {
                MessageBox.Show("Street" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidateHouse(arrivalHouse))
            {
                MessageBox.Show("House" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidatePorch(arrivalPorch))
            {
                MessageBox.Show("Porch" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidateStreet(departureStreet))
            {
                MessageBox.Show("Street" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidateHouse(departureHouse))
            {
                MessageBox.Show("House" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidatePorch(departurePorch))
            {
                MessageBox.Show("Porch" + message, caption, buttons);
                return;
            }
            else if (!this.validator.ValidateTime(time)) 
            {
                MessageBox.Show("Time" + message, caption, buttons);
                return;
            }

            this.builder.SetName(name);
            this.builder.SetPhoneNumber(phone);
            this.builder.SetAddressOfDeparture($"{arrivalStreet};{arrivalHouse};{arrivalPorch}");
            this.builder.SetAddressOfArrival($"{departureStreet};{departureHouse};{departurePorch}");
            this.builder.SetTimeOfArrival(time);
            this.builder.SetClassOfTaxi(textBoxClassOfTheTaxi.Text);
            this.database.AddOrder(this.builder.Build());
            using (var cont=new OrderContext())
            {
                cont.Orders.Add(this.builder.Build());
                cont.SaveChanges();
            }
                MessageBox.Show("Ваше замовлення успішно додано, за вами виїхали");
        }
    }
}

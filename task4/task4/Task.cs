using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public class Task
    {
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        private void OpenConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void ShowResults(SqlCommand command, string queryDescription)
        {
            Console.WriteLine("\n\n" + queryDescription);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }

        //Show the first and last name(s) of the eldest employee(s).
        private void Task9()
        {
            string queryDescr = "Show the first and last name(s) of the eldest employee(s).";
            command.CommandText = "SELECT LastName, FirstName FROM Employees WHERE BirthDate=(SELECT MIN(BirthDate) FROM Employees) GROUP BY LastName, FirstName;";
            ShowResults(command, queryDescr);
        }

        //Show first, last names and ages of 3 eldest employees.
        private void Task10()
        {
            string queryDescr = "Show first, last names and ages of 3 eldest employees.";
            command.CommandText = "SELECT TOP 3 LastName, FirstName," +
                " CASE WHEN MONTH(BirthDate) > MONTH(getdate()) THEN Year(getdate()) - Year(BirthDate) - 1" +
                " WHEN MONTH(BirthDate) = MONTH(getdate()) AND Day(BirthDate) > DAY(getdate()) THEN Year(getdate()) - Year(BirthDate) - 1" +
                " ELSE Year(getdate()) - Year(BirthDate) END AS Age" +
                " FROM Employees ORDER BY BirthDate;";
            ShowResults(command, queryDescr);
        }

        //Show the list of all cities where the employees are from.
        private void Task11()
        {
            string queryDescr = "Show the list of all cities where the employees are from.";
            command.CommandText = "SELECT City FROM Employees GROUP BY CITY;";
            ShowResults(command, queryDescr);
        }

        //Show first, last names and dates of birth of the employees who celebrate their birthdays this month.
        private void Task12()
        {
            string queryDescr = "Show first, last names and dates of birth of the employees who celebrate their birthdays this month.";
            command.CommandText = "SELECT LastName, FirstName FROM Employees WHERE MONTH(BirthDate) = (MONTH(getdate())) GROUP BY LastName, FirstName;";
            ShowResults(command, queryDescr);
        }

        //Show first and last names of the employees who used to serve orders shipped to Madrid.
        private void Task13()
        {
            string queryDescr = "Show first and last names of the employees who used to serve orders shipped to Madrid.";
            command.CommandText = "SELECT LastName, FirstName FROM Employees JOIN Orders on Employees.EmployeeID = Orders.EmployeeID and ShipCity = 'Madrid' GROUP BY LastName, FirstName;";
            ShowResults(command, queryDescr);
        }

        //Show the list of french customers’ names who have made more than one order
        private void Task18()
        {
            string queryDescr = "Show the list of french customers’ names who have made more than one order.";
            command.CommandText = "SELECT ContactName FROM Customers, Orders WHERE Country='France' GROUP BY ContactName HAVING COUNT(Orders.CustomerID) > 1;";
            ShowResults(command, queryDescr);
        }

        //Show the list of employees’ names along with names of their chiefs.
        private void Task29()
        {
            string queryDescr = "Show the list of employees’ names along with names of their chiefs.";
            command.CommandText = "SELECT E1.FirstName AS Name, E2.FirstName AS Chief FROM Employees E1 LEFT JOIN Employees E2 ON E1.ReportsTo = E2.EmployeeID;";
            ShowResults(command, queryDescr);
        }

        //Show the list of cities where employees and customers are from and where orders have been made to.Duplicates should be eliminated.
        private void Task30()
        {
            string queryDescr = "Show the list of cities where employees and customers are from and where\n" +
                "orders have been made to. Duplicates should be eliminated.";
            command.CommandText = "SELECT City FROM Employees UNION SELECT City FROM Customers UNION SELECT ShipCity FROM Orders;";
            ShowResults(command, queryDescr);
        }

        public void ExecuteTasks()
        {
            OpenConnection();
            if (connection != null)
            {
                command = connection.CreateCommand();
                Task9();
                Task10();
                Task11();
                Task12();
                Task13();
                Task18();
                Task29();
                Task30();
                CloseConnection();
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
            }
        }
    }
}

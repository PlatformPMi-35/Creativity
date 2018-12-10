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
                    Console.Write( "{0,-20}",reader[i] );
                }
                Console.WriteLine();
            }
            reader.Close();
            Console.ReadLine();

        }

        //Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.
        private void Task4()
        {
            string queryDescr = "Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.";
            command.CommandText = @"SELECT FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age
                                                FROM Employees 
                                                WHERE DATEDIFF(year, BirthDate, GETDATE()) > 55 
                                                ORDER BY LastName;";
            ShowResults(command, queryDescr);
        }

        //Calculate the count of employees from London.
        private void Task5()
        {
            string queryDescr = "Calculate the count of employees from London.";
            command.CommandText = "SELECT COUNT(*) AS EmployeeQuantity FROM Employees WHERE City='London';";
            ShowResults(command, queryDescr);
        }

        //Calculate the greatest, the smallest and the average age among the employees from London
        private void Task6()
        {
            string queryDescr="Calculate the greatest, the smallest and the average age among the employees from London.";
            command.CommandText = @"SELECT MAX(DATEDIFF(year, BirthDate, GETDATE())) AS MaxYears, 
                                                       MIN(DATEDIFF(year, BirthDate, GETDATE())) AS MinYears,
                                                       AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgYears 
                                                FROM Employees 
                                                WHERE City='London';";
            ShowResults(command, queryDescr);
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

        //Show first and last names of the employees as well as the count of their orders shipped after required date during the year 1997(use left join).
        private void Task16()
        {
            string queryDescr = "Show first and last names of the employees as well as the count of their orders shipped after required date during the year 1997(use left join).";
            command.CommandText = @"SELECT Emp.FirstName, Emp.LastName, COUNT(Ord.EmployeeID) AS OrdersAmount 
                                                FROM Employees AS Emp
                                                LEFT JOIN Orders AS Ord ON Ord.EmployeeID = Emp.EmployeeID 
                                                WHERE Ord.ShippedDate > Ord.RequiredDate 
                                                AND Ord.OrderDate BETWEEN '1997-01-01' AND '1997-12-31' 
                                                GROUP BY Emp.FirstName, Emp.LastName;";
            ShowResults(command, queryDescr);
        }

        //Show the count of orders made by each customer from France.
        private void Task17()
        {
            string queryDescr = "Show the count of orders made by each customer from France.";
            command.CommandText = @"SELECT C.ContactName, COUNT(Ord.CustomerID) AS OrdersAmount 
                                                FROM Customers AS C 
                                                INNER JOIN Orders AS Ord ON Ord.CustomerID = C.CustomerID 
                                                WHERE C.Country = 'France' 
                                                GROUP BY C.ContactName;";
            ShowResults(command, queryDescr);
        }

        //Show the list of french customers’ names who have made more than one order
        private void Task18()
        {
            string queryDescr = "Show the list of french customers’ names who have made more than one order.";
            command.CommandText = "SELECT ContactName FROM Customers, Orders WHERE Country='France' GROUP BY ContactName HAVING COUNT(Orders.CustomerID) > 1;";
            ShowResults(command, queryDescr);
        }
        //Show the list of french customers’ names who used to order french products.
        private void Task24()
        {
            string queryDescr = "Show the list of french customers’ names who used to order french products.";
            command.CommandText = "SELECT DISTINCT c.ContactName FROM Customers AS c, " +
                "Orders AS o WHERE c.CustomerID=o.CustomerID AND c.Country='France'" +
                " AND o.ShipCountry='France';";
            ShowResults(command, queryDescr);
        }

        //Show the total ordering sum calculated for each country of customer.
        private void Task25()
        {
            string queryDescr = "Show the total ordering sum calculated for each country of customer.";
            command.CommandText = @"SELECT Ord.ShipCountry, Sum(Ode.ExtendedPrice) AS TotalPriceSum
                                    FROM Orders Ord 
                                    INNER JOIN [Order Details Extended] Ode ON Ode.OrderID = Ord.OrderID
                                    GROUP BY Ord.ShipCountry;";
            ShowResults(command, queryDescr);
        }

        //Show the total ordering sums calculated for each customer’s country for domestic and non-domestic 
        //products separately (e.g.: “France – French products ordered – Non-french products ordered” and so 
        //on for each country).
        private void Task26()
        {
            string queryDescr = "Show the total ordering sums calculated for each customer’s country for domestic " +
                "and non-domestic products separately (e.g.: “France – French products ordered – Non-french products " +
                "ordered” and so on for each country).";
            command.CommandText = @"SELECT D1.Country, D1.Domestic, D2.NonDomestic 
                FROM 
                (SELECT C.Country, COUNT (P.ProductID) AS Domestic 
                FROM Customers AS C 
                LEFT JOIN Orders AS Ord ON C.CustomerID = Ord.CustomerID 
                LEFT JOIN [Order Details] AS OD ON Ord.OrderID = OD.OrderID 
                LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID 
                LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID 
                WHERE S.country = C.Country 
                GROUP BY C.Country) AS D1 
                LEFT JOIN 
                (SELECT C.Country, COUNT (P.ProductID) AS NonDomestic 
                FROM Customers AS C 
                LEFT JOIN Orders AS Ord ON C.CustomerID = Ord.CustomerID 
                LEFT JOIN [Order Details] AS OD ON Ord.OrderID = OD.OrderID 
                LEFT JOIN [Products] AS P ON OD.ProductID = P.ProductID 
                LEFT JOIN [Suppliers] AS S ON P.SupplierID = S.SupplierID 
                WHERE S.country <> C.Country 
                GROUP BY C.Country) AS D2 
                ON D1.Country = D2.Country;";
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

        //Insert 5 new records into Employees table. Fill in the following  fields:
        //LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes. The Notes field should contain your own name.
        private void Task31()
        {
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
                " VALUES ('Boyko', 'Danylo',  '1998-01-18', '2018-12-1', 'Shevchenka 5', 'Lviv', 'Ukraine', 'Kamila');";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
                " VALUES ('Tarasenko', 'Vika',  '1999-09-11', '2018-12-6', 'Ozerna 15', 'Lviv', 'Ukraine', 'Kamila');";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
               " VALUES ('Romanko', 'Diana',  '1992-12-12', '2018-12-6', 'Lychakivska 111', 'Lviv', 'Ukraine', 'Kamila');";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
               " VALUES ('Kobak', 'Viktor',  '1995-09-11', '2018-12-6', 'Kotlyarevskoho 200', 'Lviv', 'Ukraine', 'Kamila');";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
               " VALUES ('Romaniv', 'Petro',  '1992-01-11', '2018-12-6', 'Stryjska 25', 'Lviv', 'Ukraine', 'Kamila');";
            command.ExecuteNonQuery();
            Console.WriteLine("\n\nInserted 5 employees");
        }

        //Change the City field in one of your records using the UPDATE statement
        private void Task33()
        {

            command.CommandText = "UPDATE Employees " +
                                  "SET City = 'Kyiv' " +
                                  "WHERE LastName = 'Romaniv' OR LastName='Romanko';";
            Console.WriteLine("\n\nUpdate {0} row(s)", command.ExecuteNonQuery());
        }

        public void ExecuteTasks()
        {
            OpenConnection();
            if (connection != null)
            {
                command = connection.CreateCommand();
                Task4();
                Task5();
                Task6();
                Task9();
                Task10();
                Task11();
                Task12();
                Task13();
                Task16();
                Task17();
                Task18();
                Task24();
                Task25();
                Task26();
                Task29();
                Task30();
                Task31();
                Task33();
                CloseConnection();
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
            }
        }
    }
}

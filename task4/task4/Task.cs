//-----------------------------------------------------------------------
// <copyright file="Task.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Data.SqlClient;

namespace task4
{
    /// <summary>
    /// Performs executing of queries
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Connection string to Northwind database
        /// </summary>
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NORTHWNDConnectionString"].ConnectionString;

        /// <summary>
        /// Represents a unique session to a SQL Server data source.
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Allows to query and send commands to a database
        /// </summary>
        private SqlCommand command;

        /// <summary>
        /// Is used to read data from a data source
        /// </summary>
        private SqlDataReader reader;

        /// <summary>
        /// Execute all tasks
        /// </summary>
        public void ExecuteTasks()
        {
            this.OpenConnection();
            if (this.connection != null)
            {
                this.command = this.connection.CreateCommand();
                this.Task4();
                this.Task5();
                this.Task6();
                this.Task9();
                this.Task10();
                this.Task11();
                this.Task12();
                this.Task13();
                this.Task16();
                this.Task17();
                this.Task18();
                this.Task24();
                this.Task25();
                this.Task26();
                this.Task29();
                this.Task30();
                this.Task31();
                this.Task33();
                this.CloseConnection();
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
            }
        }

        /// <summary>
        /// Opens connection to database
        /// </summary>
        private void OpenConnection()
        {
            try
            {
                this.connection = new SqlConnection(this.connectionString);
                this.connection.Open();
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

        /// <summary>
        /// Closes connection to database
        /// </summary>
        private void CloseConnection()
        {
            try
            {
                this.connection.Close();
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

        /// <summary>
        /// Shows results of query
        /// </summary>
        /// <param name="command">Command to execute</param>
        /// <param name="queryDescription">Describes what query is doing</param>
        private void ShowResults(SqlCommand command, string queryDescription)
        {
            Console.WriteLine("\n\n" + queryDescription);
            this.reader = command.ExecuteReader();
            while (this.reader.Read())
            {
                for (int i = 0; i < this.reader.FieldCount; i++)
                {
                    Console.Write("{0,-20}", this.reader[i]);
                }

                Console.WriteLine();
            }

            this.reader.Close();
            Console.ReadLine();
        }

        /// <summary>
        /// Query to show the list of first, last names and ages of the employees whose age is greater than 55. 
        /// The result is sorted by last name.
        /// </summary>
        private void Task4()
        {
            string queryDescr = "Show the list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name.";
            this.command.CommandText = @"SELECT FirstName, LastName, DATEDIFF(year, BirthDate, GETDATE()) AS Age
                                                FROM Employees 
                                                WHERE DATEDIFF(year, BirthDate, GETDATE()) > 55 
                                                ORDER BY LastName;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Calculate the count of employees from London.
        /// </summary>
        private void Task5()
        {
            string queryDescr = "Calculate the count of employees from London.";
            this.command.CommandText = "SELECT COUNT(*) AS EmployeeQuantity FROM Employees WHERE City='London';";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Calculate the greatest, the smallest and the average age among the employees from London
        /// </summary>
        private void Task6()
        {
            string queryDescr = "Calculate the greatest, the smallest and the average age among the employees from London.";
            this.command.CommandText = @"SELECT MAX(DATEDIFF(year, BirthDate, GETDATE())) AS MaxYears, 
                                                       MIN(DATEDIFF(year, BirthDate, GETDATE())) AS MinYears,
                                                       AVG(DATEDIFF(year, BirthDate, GETDATE())) AS AvgYears 
                                                FROM Employees 
                                                WHERE City='London';";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the first and last name(s) of the eldest employee(s).
        /// </summary>
        private void Task9()
        {
            string queryDescr = "Show the first and last name(s) of the eldest employee(s).";
            this.command.CommandText = "SELECT LastName, FirstName FROM Employees WHERE BirthDate=(SELECT MIN(BirthDate) FROM Employees) GROUP BY LastName, FirstName;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show first, last names and ages of 3 eldest employees.
        /// </summary>
        private void Task10()
        {
            string queryDescr = "Show first, last names and ages of 3 eldest employees.";
            this.command.CommandText = "SELECT TOP 3 LastName, FirstName," +
                " CASE WHEN MONTH(BirthDate) > MONTH(getdate()) THEN Year(getdate()) - Year(BirthDate) - 1" +
                " WHEN MONTH(BirthDate) = MONTH(getdate()) AND Day(BirthDate) > DAY(getdate()) THEN Year(getdate()) - Year(BirthDate) - 1" +
                " ELSE Year(getdate()) - Year(BirthDate) END AS Age" +
                " FROM Employees ORDER BY BirthDate;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the list of all cities where the employees are from.
        /// </summary>
        private void Task11()
        {
            string queryDescr = "Show the list of all cities where the employees are from.";
            this.command.CommandText = "SELECT City FROM Employees GROUP BY CITY;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show first, last names and dates of birth of the employees who celebrate their birthdays this month.
        /// </summary>
        private void Task12()
        {
            string queryDescr = "Show first, last names and dates of birth of the employees who celebrate their birthdays this month.";
            this.command.CommandText = "SELECT LastName, FirstName FROM Employees WHERE MONTH(BirthDate) = (MONTH(getdate())) GROUP BY LastName, FirstName;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show first and last names of the employees who used to serve orders shipped to Madrid.
        /// </summary>
        private void Task13()
        {
            string queryDescr = "Show first and last names of the employees who used to serve orders shipped to Madrid.";
            this.command.CommandText = "SELECT LastName, FirstName FROM Employees JOIN Orders on Employees.EmployeeID = Orders.EmployeeID and ShipCity = 'Madrid' GROUP BY LastName, FirstName;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show first and last names of the employees as well as the count of their orders shipped after required 
        /// date during the year 1997(use left join).
        /// </summary>
        private void Task16()
        {
            string queryDescr = "Show first and last names of the employees as well as the count of their orders shipped after required date during the year 1997(use left join).";
            this.command.CommandText = @"SELECT Emp.FirstName, Emp.LastName, COUNT(Ord.EmployeeID) AS OrdersAmount 
                                                FROM Employees AS Emp
                                                LEFT JOIN Orders AS Ord ON Ord.EmployeeID = Emp.EmployeeID 
                                                WHERE Ord.ShippedDate > Ord.RequiredDate 
                                                AND Ord.OrderDate BETWEEN '1997-01-01' AND '1997-12-31' 
                                                GROUP BY Emp.FirstName, Emp.LastName;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the count of orders made by each customer from France.
        /// </summary>
        private void Task17()
        {
            string queryDescr = "Show the count of orders made by each customer from France.";
            this.command.CommandText = @"SELECT C.ContactName, COUNT(Ord.CustomerID) AS OrdersAmount 
                                                FROM Customers AS C 
                                                INNER JOIN Orders AS Ord ON Ord.CustomerID = C.CustomerID 
                                                WHERE C.Country = 'France' 
                                                GROUP BY C.ContactName;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the list of french customers’ names who have made more than one order
        /// </summary>
        private void Task18()
        {
            string queryDescr = "Show the list of french customers’ names who have made more than one order.";
            this.command.CommandText = "SELECT ContactName FROM Customers, Orders WHERE Country='France' GROUP BY ContactName HAVING COUNT(Orders.CustomerID) > 1;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the list of french customers’ names who used to order french products.
        /// </summary>
        private void Task24()
        {
            string queryDescr = "Show the list of french customers’ names who used to order french products.";
            this.command.CommandText = "SELECT DISTINCT c.ContactName FROM Customers AS c, " +
                "Orders AS o WHERE c.CustomerID=o.CustomerID AND c.Country='France'" +
                " AND o.ShipCountry='France';";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the total ordering sum calculated for each country of customer.
        /// </summary>
        private void Task25()
        {
            string queryDescr = "Show the total ordering sum calculated for each country of customer.";
            this.command.CommandText = @"SELECT Ord.ShipCountry, Sum(Ode.ExtendedPrice) AS TotalPriceSum
                                    FROM Orders Ord 
                                    INNER JOIN [Order Details Extended] Ode ON Ode.OrderID = Ord.OrderID
                                    GROUP BY Ord.ShipCountry;";
            this.ShowResults(this.command, queryDescr);
        }
        
        /// <summary>
        /// Query to show the total ordering sums calculated for each customer’s country for domestic and non-domestic
        /// products separately (e.g.: “France – French products ordered – Non-french products ordered” and so on for 
        /// each country).
        /// </summary>
        private void Task26()
        {
            string queryDescr = "Show the total ordering sums calculated for each customer’s country for domestic " +
                "and non-domestic products separately (e.g.: “France – French products ordered – Non-french products " +
                "ordered” and so on for each country).";
            this.command.CommandText = @"SELECT D1.Country, D1.Domestic, D2.NonDomestic 
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
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the list of employees’ names along with names of their chiefs.
        /// </summary>
        private void Task29()
        {
            string queryDescr = "Show the list of employees’ names along with names of their chiefs.";
            this.command.CommandText = "SELECT E1.FirstName AS Name, E2.FirstName AS Chief FROM Employees E1 LEFT JOIN Employees E2 ON E1.ReportsTo = E2.EmployeeID;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to show the list of cities where employees and customers are from and where orders have been made to. Duplicates are eliminated.
        /// </summary>
        private void Task30()
        {
            string queryDescr = "Show the list of cities where employees and customers are from and where\n" +
                "orders have been made to. Duplicates should be eliminated.";
            this.command.CommandText = "SELECT City FROM Employees UNION SELECT City FROM Customers UNION SELECT ShipCity FROM Orders;";
            this.ShowResults(this.command, queryDescr);
        }

        /// <summary>
        /// Query to Insert 5 new records into Employees table. Fills in the following  fields:
        /// LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes. The Notes field contains your own name.
        /// </summary>
        private void Task31()
        {
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
                " VALUES ('Boyko', 'Danylo',  '1998-01-18', '2018-12-1', 'Shevchenka 5', 'Lviv', 'Ukraine', 'Kamila');";
            this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
                " VALUES ('Tarasenko', 'Vika',  '1999-09-11', '2018-12-6', 'Ozerna 15', 'Lviv', 'Ukraine', 'Kamila');";
            this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
               " VALUES ('Romanko', 'Diana',  '1992-12-12', '2018-12-6', 'Lychakivska 111', 'Lviv', 'Ukraine', 'Kamila');";
            this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
               " VALUES ('Kobak', 'Viktor',  '1995-09-11', '2018-12-6', 'Kotlyarevskoho 200', 'Lviv', 'Ukraine', 'Kamila');";
            this.command.ExecuteNonQuery();
            this.command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, Address, City, Country, Notes)" +
               " VALUES ('Romaniv', 'Petro',  '1992-01-11', '2018-12-6', 'Stryjska 25', 'Lviv', 'Ukraine', 'Kamila');";
            this.command.ExecuteNonQuery();
            Console.WriteLine("\n\nInserted 5 employees");
        }
        
        /// <summary>
        /// Query to change the City field in one of your records using the UPDATE statement
        /// </summary>
        private void Task33()
        {
            this.command.CommandText = "UPDATE Employees " +
                      "SET City = 'Kyiv' " +
                      "WHERE LastName = 'Romaniv' OR LastName='Romanko';";
            Console.WriteLine("\n\nUpdate {0} row(s)", this.command.ExecuteNonQuery());
        }
    }
}

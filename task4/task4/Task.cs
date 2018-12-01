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
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public void OpenConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (SqlException sqlexception)
            {
                Console.WriteLine(sqlexception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                    connection.Close();
            }
            catch (SqlException sqlexception)
            {
                Console.WriteLine(sqlexception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

       
    }
}

using System;
using System.Data.SqlClient;

namespace database_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;MultipleActiveResultSets=true;";
            // Connection creation
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Opening connection
                connection.Open();
                Console.WriteLine("Connection is opened");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //select
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Employees";
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    string firstName = (string)reader.GetValue(2);
                    string lastName = (string)reader.GetValue(1);

                    Console.WriteLine($"First name: {firstName} \t  Last name: {lastName}");
                }
            }
            //insert
            string sqlExpression = "INSERT INTO Employees (FirstName, LastName) VALUES ('Tamara', 'Potehina'), ('Denis', 'Lopatin')";

            command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("Добавлено объектов: {0}", number);
            //update
            sqlExpression = "UPDATE Employees SET FirstName='TamaraP' WHERE LastName='Potehina'";
            command = new SqlCommand(sqlExpression, connection);
            number = command.ExecuteNonQuery();
            Console.WriteLine("Обновлено объектов: {0}", number);
            //delete
            sqlExpression = "DELETE  FROM Employees WHERE LastName='Potehina' OR LastName='Lopatin'";
            command = new SqlCommand(sqlExpression, connection);
            number = command.ExecuteNonQuery();
            Console.WriteLine("Удалено объектов: {0}", number);

            //stored procedures
            sqlExpression = "CustOrdersDetail";
            command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            
            SqlParameter nameParam = new SqlParameter
            {
                ParameterName = "@OrderId",
                Value = 10248
            };
            
            command.Parameters.Add(nameParam);

            reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    object productName = reader.GetValue(0);
                    object unitPrice = reader.GetValue(1);
                    object qty = reader.GetValue(2);
                    object extendedPrice = reader.GetValue(4);

                    Console.WriteLine($"{productName}\t{unitPrice}\t{qty}\t{extendedPrice}");
                }
            }
            Console.Read();
            // closing connection
            connection.Close();
            Console.WriteLine("Connection is closed...");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BankSystem
{
    public class DatabaseConnection
    {
        private string connectionString = @"Server=LAPTOP-44N5F7A0;Database=Banksystem;Integrated Security=True;";

        public void InsertCustomer(int customerId, string firstname, string lastname, string phoneNumber, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customer (CustomerId, Firstname, Lastname, PhoneNumber, Email) " +
                                "VALUES (@CustomerId, @Firstname, @Lastname, @PhoneNumber, @Email);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@Firstname", firstname);
                    command.Parameters.AddWithValue("@Lastname", lastname);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }

        public void InsertAccount(int accountNumber, decimal saldo, int customerId) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Account (AccountNumber, Saldo, CustomerId)" +
                                "VALUES (@AccountNumber, @Saldo, @CustomerId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.Parameters.AddWithValue("@Saldo", saldo);
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

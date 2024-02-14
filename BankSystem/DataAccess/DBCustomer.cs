using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankSystem.DataAccess
{
    public class DBCustomer
    {
        private string connectionString = default!;

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
    }
}

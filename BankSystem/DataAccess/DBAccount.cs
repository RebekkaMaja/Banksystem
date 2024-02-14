using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.DataAccess
{
    public class DBAccount
    {
        private string connectionString = default!;
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

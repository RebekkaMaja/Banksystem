using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal Saldo { get; private set; }
        public Customer Customer { get; set; }


        //Constructor
        public Account(Customer customer)
        {
            this.Customer = customer;
            this.Saldo = 0;
        }

        public Account(int accountNumber, decimal saldo)
        {
            this.AccountNumber = accountNumber;
            this.Saldo = saldo;
        }

        

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Saldo += amount;
                Console.WriteLine("Deposit succesful. Balance: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive");
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= Saldo && amount > 0)
            {
                Saldo -= amount;
                Console.WriteLine($"Withrawal successful. New balance: {Saldo:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid amount");
                return false;
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"The balance for account {AccountNumber} is {Saldo:C}");
        }

    }

  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Customer
    {
        private static int nextID = 1;
        private readonly Account account;

        public int CustomerID { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }


        public Customer(string firstname, string lastname, string phoneNumber, string email)
        {
            CustomerID = nextID++;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

    

        private bool IsValidPhone(string phone)
        {
            // Check if the phone number is between 8 and 20 digits
            return Regex.IsMatch(phone, @"\d{8,20}");
        }
        public void UpdatePhoneNumber(string newPhoneNumber)
        {
            if (IsValidPhone(newPhoneNumber))
            {
                PhoneNumber = newPhoneNumber;
                Console.WriteLine("PhoneNumber updated.");
            }
            else
            {
                Console.WriteLine("Invalid phone number format.");
            }
        }

        public void UpdateEmail(string newEmail)
        {
            if (IsValidEmail(newEmail))
            {
                Email = newEmail;
                Console.WriteLine("Email updated.");
            }
            else
            {
                Console.WriteLine("Invalid email format.");
            }
        }

        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer ID: {CustomerID}\nName: {Firstname} {Lastname}\nPhone: {PhoneNumber}\nEmail: {Email}");
        }

   

     //   private bool IsValidEmail(string email)
       // {
         //   return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
       // }

        private bool IsValidEmail(string email)
        {
            try
            {
                Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return true;
            }
            catch { return false; }

        }

    }
       
}

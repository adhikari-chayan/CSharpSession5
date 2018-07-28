using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library
{
   public abstract class Account
    {
        private Customer customer;
        private double balance;
        private double interestRate;

        public Customer Customer { get; private set; }
        public double Balance { get; private set; }
        public double InterestRate { get;  set; }

        public string AccountNumber { get; set; }
        public Account(Customer customer, double balance,string accountNumber)
        {
            this.Customer = customer;
            this.Balance = balance;

            this.AccountNumber = accountNumber;
            
        }



        public abstract double CalculateInterestAmount(int numberOfMonths);
        public virtual double Deposit(double amount)
        {
            //this.Balance = this.Balance + amount;
            //return this.Balance;
            return this.Balance += amount;
        }

        public String GetAccountType()
        {
            if(this is DepositAccount)
            {
                return "Deposit";
            }
            else if(this is MortgageAccount)
            {
                return "Mortgage";
            }
            else
            {
                return "Loan";
            }
        }
    }
}

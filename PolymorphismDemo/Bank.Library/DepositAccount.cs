using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library
{
   public class DepositAccount:Account
    {
        public DepositAccount(Customer customer, double balance, string accountNumber) : base(customer, balance,accountNumber)
        {
            InterestRate = 0.2;
        }

        public override double CalculateInterestAmount(int numberOfMonths)
        {
            double interest = 0.0;
            if (this.Balance < 1000)
            {
                interest = 0.0;
            }
            else
            {
                interest = numberOfMonths * this.InterestRate;
            }
            return interest;
        }
        public double Withdraw(double amount)
        {

            double result = 0.0;
            if (amount > this.Balance)
            {
                return result = 0.0;
            }

            else
            {
                result = this.Balance - amount;
            }


            return result;
        }

        public override double Deposit(double amount)
        {
            //If I want to give a 20$ benefit for each deposit
            amount = amount + 20;
            return base.Deposit(amount);
        }
    }
}

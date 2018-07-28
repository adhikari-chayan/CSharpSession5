using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library
{
   public class MortgageAccount:Account
    {
        public MortgageAccount(Customer customer, double balance, string accountNumber) : base(customer, balance, accountNumber)
        {
            InterestRate = 0.2;
        }


        public override double CalculateInterestAmount(int numberOfMonths)
        {
            double interest = 0.0;
            if (this.Customer is CompanyCustomer)
            {
                if (numberOfMonths <= 12)
                {
                    interest = (numberOfMonths * this.InterestRate) / 2;
                }
                else
                {
                    interest = (((12 * this.InterestRate) / 2) + ((numberOfMonths - 12) * this.InterestRate));
                }
            }

            if (this.Customer is IndividualCustomer)
            {
                if (numberOfMonths <= 6)
                {
                    interest = 0.0;
                }
                else
                {
                    interest = (numberOfMonths - 6) * this.InterestRate;
                }
            }

            return interest;
        }
    }
}

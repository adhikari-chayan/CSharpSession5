using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library
{
   public class LoanAccount:Account
    {
        public LoanAccount(Customer customer, double balance, string accountNumber) : base(customer, balance,accountNumber)
        {
            InterestRate = 3.2;
        }

        public override double CalculateInterestAmount(int numberOfMonths)
        {
            double interest = 0.0;

            if (this.Customer is IndividualCustomer)
            {
                if (numberOfMonths > 3)
                {
                    interest = (numberOfMonths - 3) * this.InterestRate;
                }
                else
                {
                    interest = 0.0;
                }

            }

            if (this.Customer is CompanyCustomer)
            {
                if (numberOfMonths > 2)
                {
                    interest = (numberOfMonths - 2) * this.InterestRate;
                }
                else
                {
                    interest = 0.0;
                }
            }

            return interest;
        }
    }
}

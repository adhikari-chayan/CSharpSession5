using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library
{
   public abstract class Customer
    {
        public int CustomerId { get; set; }

        public abstract string GetName();

        public string GetCustomerType()
        {
            if(this is IndividualCustomer)
            {
                return "Individual";
            }
            else
            {
                return "Company";
            }
        }
      
    }
}

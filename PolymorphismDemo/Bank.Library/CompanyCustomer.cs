using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Library
{
    public class CompanyCustomer:Customer
    {
        public string CompanyName { get; set; }

        public override string GetName()
        {
            return CompanyName;
        }
    }
}

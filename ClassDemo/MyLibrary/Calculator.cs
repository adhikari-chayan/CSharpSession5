using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
   public class Calculator
    {
        //private field
        private double sum;

        static int s_usageCount;
        public double Sum { get; set; }

        public static int UsageCount { get; private set; }

       // public double Sum { get; private set; }
        public Calculator(double initialValue)
        {
            sum = initialValue;
        }

        public Calculator():this(0)
        {

        }

        static Calculator()
        {
            Console.WriteLine("Static Ctor fired!!");
        }
        public double Add(double a,double b)
        {
            return a + b;
        }

        public void Add(double a)
        {
            // ++s_usageCount;
            ++UsageCount;
            //sum += a;
            this.Sum += a;
        }

        //public accessor to private accessor
        public double GetSum()
        {
            return sum;
        }

        //public double Sum
        //{
        //    get
        //    {
        //        return sum;
        //    }
        //    set
        //    {
        //        sum = value;
        //    }
        //}

        public static int GetUsageCount()
        {
            return s_usageCount;
        }

        //public static int UsageCount
        //{
        //    get
        //    {
        //        return s_usageCount;
        //    }
        //}

    }
}

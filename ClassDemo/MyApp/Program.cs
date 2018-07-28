using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            // double result = calc.Add(4, 5);
            Calculator calc4 = new Calculator();
            Calculator calc5 = new Calculator();
            Calculator calc6 = new Calculator();
            Calculator calc7 = new Calculator();


            //Console.WriteLine(Calculator.GetUsageCount());
            Console.WriteLine(Calculator.UsageCount);
            calc.Add(4);
            calc.Add(5);
            //Console.WriteLine(Calculator.GetUsageCount());
            Console.WriteLine(Calculator.UsageCount);
            double result = calc.GetSum();

          //  Calculator calc2 = new Calculator();
            Calculator calc2 = calc;
            

            result = calc2.GetSum();

            Console.WriteLine(
                object.ReferenceEquals(calc, calc2)
                );
            Console.WriteLine("4 + 5 = {0}", result);
            
            Console.ReadKey();
        }
    }
}

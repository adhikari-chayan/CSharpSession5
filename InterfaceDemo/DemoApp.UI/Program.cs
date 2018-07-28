using DemoApp.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");
            var fileLogger = new FileSystemLogger();
            fileLogger.LogMessage(DateTime.Now.ToString() + " : Hello World has been executed");

            var emailLogger = new EmailLogger();
            emailLogger.LogMessage(DateTime.Now.ToString() + " : Hello World has been executed");

            Console.ReadKey();

        }
    }
}

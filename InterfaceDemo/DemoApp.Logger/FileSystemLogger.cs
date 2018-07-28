using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Logger
{
    public class FileSystemLogger : ILogger
    {
        public void LogMessage(string message)
        {
            using (StreamWriter writer =
             new StreamWriter("log.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}

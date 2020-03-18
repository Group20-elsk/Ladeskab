using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadeskabLogik
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void writeLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem.IO
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem.IO
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string messageToWrite)
        {
            Console.WriteLine(messageToWrite);
        }
        public void Write(string messageToWrite)
        {
            Console.Write(messageToWrite);
        }
    }
}

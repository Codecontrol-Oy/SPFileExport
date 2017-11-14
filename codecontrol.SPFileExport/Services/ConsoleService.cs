using System;
namespace codecontrol.SPFileExport.Services
{
    public class ConsoleService
    {
        public virtual string ReadInput()
        {
            return Console.ReadLine();
        }

        public virtual void WriteLineToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public virtual void WriteToConsole(string message)
        {
            Console.Write(message);
        }
    }
}

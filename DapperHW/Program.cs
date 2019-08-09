using System;

namespace DapperHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            UI user = new UI();
            user.UserChoice();
        }
    }
}

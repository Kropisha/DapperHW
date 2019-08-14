using System;

namespace DapperHW
{
    class UI
    {
        public void UserChoice()
        {
            Console.Title = " CRUD with Dapper [Kropyvna Yuliia]";
            UsersAction action;
            Data data = new Data();
            BL bl = new BL();
            Console.ResetColor();
            do
            {
                Console.SetCursorPosition(0, 0);
                Enum.TryParse(this.ShowMenu("    Welcome to the dapper task!       ").ToString(), out action);
                Console.WriteLine();
                Console.ResetColor();

                switch (action)
                {
                    case UsersAction.Get:

                        Console.ResetColor();
                        bl.GetCase();
                        Console.ReadKey();
                        break;
                    case UsersAction.Create:
                        Console.ResetColor();
                        bl.CreateCase();
                        break;
                    case UsersAction.Update:
                        Console.ResetColor();
                        bl.UpdateCase();
                        break;
                    case UsersAction.Delete:
                        Console.ResetColor();
                        bl.DeleteCase();
                        break;
                    case UsersAction.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.ResetColor();
                Console.Clear();
            }
            while (action != UsersAction.Quit);
        }

        private char ShowMenu(string type)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(type);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("           1.Get Info                 ");
            Console.WriteLine("           2.Create Info              ");
            Console.WriteLine("           3.Update Info              ");
            Console.WriteLine("           4.Delete Info              ");
            Console.WriteLine("           5.Quit                     ");
            Console.WriteLine();
            Console.WriteLine(" What is your choice? [tap number]");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            return Console.ReadKey().KeyChar;
        }
    }
}

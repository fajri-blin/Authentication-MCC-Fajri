using System;

namespace Authentication
{
    public class Menu
    {
        //Main Menu
        public ConsoleKey MainMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login User");
            Console.WriteLine("0. Exit");
            Console.WriteLine("===============");
            Console.Write("Select Menu : ");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            return keyInfo.Key;
        }

        //Sub Menu of Show User
        public ConsoleKey ShowUserMenu()
        {
            Console.WriteLine("=== User Menu ===");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("=================");
            Console.Write("Select Menu : ");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            return keyInfo.Key;
        }
    }
}

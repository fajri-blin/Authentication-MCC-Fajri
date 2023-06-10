using System;
using System.Collections.Generic;

namespace Authentication
{
    public class Program
    {
        private static List<User> userList = new List<User>();
        private static Menu menu = new Menu();

        public static void Main(string[] args)
        {
            bool status = true;

            do
            {
                switch (menu.MainMenu())
                {
                    case ConsoleKey.D1:
                        //Create User
                        Features.CreateUser(userList);
                        Console.WriteLine("Press any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        //Show all User
                        Features.ShowUser(userList, menu);
                        Console.WriteLine("Press any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D3:
                        //Search User by Its ID
                        Features.SearchUser(userList);
                        Console.WriteLine("Press any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D4:
                        //Login
                        Features.LoginUser(userList);
                        Console.WriteLine("Press any key...");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D0:
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine();
                        break;
                }
            } while (status);
        }
    }
}

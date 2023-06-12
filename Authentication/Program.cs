using System;
using System.Collections.Generic;

namespace Authentication
{
    public class Program
    {
        private static List<User> userList = new List<User>();
        private static List<Admin> adminList = new List<Admin>();
        private static Menu menu = new Menu();
        
        static Program()
        {
            Admin defaultAdmin = new Admin("admin", "123");
            adminList.Add(defaultAdmin);
        }

        public static int Login()
        {
            int userType;

            Console.WriteLine("Enter Your Username : ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Your Password : ");
            string password = Console.ReadLine();
            
            bool status = Features.LoginUser(userList, adminList, username, password);

            if(status == true)
            {
               userType = Features.CheckAdminOrUser(userList, adminList, username, password);
            }
            else
            {
                Console.WriteLine("Failed Login");
                userType = 0;
            }

            return userType;
        }

        public static void UserFeatures()
        {
            bool status = true;
            do
            {
                switch (menu.MenuEvenOdd())
                {
                    case ConsoleKey.D1:
                        //Check Even Odd
                        Console.Write("Masukkan Bilangan yang ingin di cek : ");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");
                        Console.WriteLine(EvenOdd.EvenOddCheck(x));
                        break;
                    case ConsoleKey.D2:
                        //Print All Number
                        Console.Write("Pilih (Ganjil/Genap) : ");
                        string typeNum = Console.ReadLine().ToLower();

                        Console.Write("Masukkan Limit : ");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("");

                        EvenOdd.PrintEvenOdd(limit, typeNum);
                        break;
                    case ConsoleKey.D0:
                        //Log Out
                        status = false;
                        break;
                    default:
                        Console.WriteLine("Input Invalid");
                        break;
                }
            }while (status);
        }

        public static void AdminFeatures() 
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

        public static void Main(string[] args)
        {
            int mainFeatures = Login();
            bool status = true;
            do
            {
                switch (mainFeatures)
                {
                    case 1:
                        //main feature for user
                        Console.Clear();
                        UserFeatures();

                        Console.Clear();
                        mainFeatures = Login();
                        break;
                    case 2:
                        //main features for admin
                        Console.Clear();
                        AdminFeatures();

                        Console.Clear();
                        mainFeatures = Login();
                        break;
                    case 0:
                        status = false; 
                        break;
                    default:
                        break;
                }
            }while (status);
        }
    }
}

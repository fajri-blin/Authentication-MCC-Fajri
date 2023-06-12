using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Authentication
{
    public static class Features
    {
        public static bool LoginUser(List<User> userList, List<Admin> adminList, string username, string password)
        {
            bool isLoggedIn = false;

            foreach (User user in userList)
            {
                if (user.Username == username && user.Password == password)
                {
                    isLoggedIn = true;
                    break;
                }
            }

            if (!isLoggedIn)
            {
                foreach (Admin admin in adminList)
                {
                    if (admin.Username == username && admin.Password == password)
                    {
                        isLoggedIn = true;
                        break;
                    }
                }
            }

            if (isLoggedIn)
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }

            return isLoggedIn;
        }

        public static int CheckAdminOrUser(List<User> userList, List<Admin> adminList, string username, string password)
        {
            User user = userList.Find(u => u.Username == username && u.Password == password);
            Admin admin = adminList.Find(a => a.Username == username && a.Password == password);

            if (user != null)
            {
                Console.WriteLine("Logged in as a regular user.");
                return 1;
            }
            else if (admin != null)
            {
                Console.WriteLine("Logged in as an admin.");
                return 2;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                return 0;
            }
        }

        public static void CreateUser(List<User> userList)
        {
            Console.WriteLine("\n");

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Please Input the Firstname and Lastname!!!");
                return;
            }

            string password;
            bool isValidPassword;
            do
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                isValidPassword = ValidatePassword(password);

                if (!isValidPassword)
                {
                    Console.WriteLine("Invalid password. Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one number.");
                }
            } while (!isValidPassword);

            User newUser = new User(firstName, lastName, password);
            userList.Add(newUser);

            Console.WriteLine("\nUser created successfully.");
            Console.WriteLine();
        }

        private static bool ValidatePassword(string password)
        {
            Regex uppercaseRegex = new Regex("[A-Z]");
            Regex lowercaseRegex = new Regex("[a-z]");
            Regex digitRegex = new Regex("[0-9]");

            // Check length
            if (password.Length < 8)
            {
                return false;
            }

            // Check for uppercase letter
            if (!uppercaseRegex.IsMatch(password))
            {
                return false;
            }

            // Check for lowercase letter
            if (!lowercaseRegex.IsMatch(password))
            {
                return false;
            }

            // Check for number
            if (!digitRegex.IsMatch(password))
            {
                return false;
            }

            return true;
        }

        public static void ShowUser(List<User> userList, Menu menu, int id = 0)
        {
            Console.WriteLine("\n");

            if (userList.Count == 0)
            {
                Console.WriteLine("No users found.");
                Console.WriteLine();
                return;
            }

            if (id != 0)
            {
                User selectedUser = userList.Find(u => u.Id == id);

                if (selectedUser != null)
                {
                    Console.WriteLine("Detail User : ");
                    selectedUser.ShowUserDetail();
                    Console.WriteLine();
                    return;
                }
                else
                {
                    Console.WriteLine($"User with ID {id} not found.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("=== User List ===");
            foreach (User user in userList)
            {
                user.ShowUserDetail();
                Console.WriteLine();
            }

            Console.WriteLine("Enter the ID of the user you want to edit or delete (or '0' to go back):");
            string input = Console.ReadLine();

            if (input == "")
            {
                Console.WriteLine("Invalid input. Returning to the main menu.");
                Console.WriteLine();
                return;
            }

            if (int.TryParse(input, out int userId))
            {
                if (userId == 0)
                {
                    Console.WriteLine();
                    return;
                }

                User selectedUser = userList.Find(u => u.Id == userId);

                if (selectedUser != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Selected User: {selectedUser.FirstName} {selectedUser.LastName}");

                    // Recursive call to ShowUser to display the selected user's details
                    ShowUser(userList, menu, Convert.ToInt32(input));

                    bool editOrDelete = true;
                    do
                    {
                        switch (menu.ShowUserMenu())
                        {
                            case ConsoleKey.D1:
                                EditUser(selectedUser);
                                break;
                            case ConsoleKey.D2:
                                DeleteUser(userList, selectedUser);
                                break;
                            case ConsoleKey.D0:
                                editOrDelete = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option. Please try again.");
                                break;
                        }
                    } while (editOrDelete);
                }
                else
                {
                    Console.WriteLine($"User with ID {userId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Returning to the main menu.");
                Console.WriteLine();
            }
        }

        public static void EditUser(User user)
        {
            Console.WriteLine("\n");

            Console.WriteLine("Enter previous password:");
            string previousPassword = Console.ReadLine();

            if (previousPassword == user.Password)
            {
                Console.WriteLine("Enter new first name:");
                string newFirstName = Console.ReadLine();

                Console.WriteLine("Enter new last name:");
                string newLastName = Console.ReadLine();

                string newPassword;
                bool isValidPassword;
                do
                {
                    Console.WriteLine("Enter new password:");
                    newPassword = Console.ReadLine();

                    isValidPassword = ValidatePassword(newPassword);

                    if (!isValidPassword)
                    {
                        Console.WriteLine("Invalid password. Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one number.");
                    }
                } while (!isValidPassword);

                user.EditUser(newFirstName, newLastName, newPassword);
                Console.WriteLine("User details updated successfully.");
            }
            else
            {
                Console.WriteLine("Previous password does not match. User details not updated.");
            }

            Console.WriteLine();
        }


        public static void DeleteUser(List<User> userList, User user)
        {
            Console.WriteLine("\n");

            userList.Remove(user);
            Console.WriteLine("User deleted successfully.");
            Console.WriteLine();
        }

        public static void SearchUser(List<User> userList)
        {
            Console.WriteLine("\n");

            Console.Write("Enter the ID of the user to search: ");
            if (int.TryParse(Console.ReadLine(), out int searchId))
            {
                User user = userList.Find(u => u.Id == searchId);

                if (user != null)
                {
                    Console.WriteLine($"User found!");
                    Console.WriteLine($"ID: {user.Id}");
                    Console.WriteLine($"First Name: {user.FirstName}");
                    Console.WriteLine($"Last Name: {user.LastName}");
                    Console.WriteLine($"Username: {user.Username}");
                }
                else
                {
                    Console.WriteLine($"User not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID input.");
            }

            Console.WriteLine();
        }

        public static void LoginUser(List<User> userList)
        {
            Console.WriteLine("\n");

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User user = userList.Find(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                Console.WriteLine($"Login successful!");
            }
            else
            {
                Console.WriteLine($"Invalid username or password.");
            }

            Console.WriteLine();
        }
    }
}

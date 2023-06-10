using System;

namespace Authentication
{
    public class User
    {
        private static int nextId = 1;

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }

        public User(string firstName, string lastName, string password)
        {
            Id = nextId++;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Username = GenerateUsername(FirstName, LastName);
        }

        private string GenerateUsername(string firstName, string lastName)
        {
            string username = (firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName)
                              + (lastName.Length >= 2 ? lastName.Substring(0, 2) : lastName);
            return username.ToLower();
        }

        public void EditUser(string newFirstName, string newLastName, string newPassword)
        {
            FirstName = newFirstName;
            LastName = newLastName;
            Password = newPassword;
            Username = GenerateUsername(newFirstName, newLastName);
        }

        public void ShowUserDetail()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"First Name: {this.FirstName}");
            Console.WriteLine($"Last Name: {this.LastName}");
            Console.WriteLine($"Username: {this.Username}");
            Console.WriteLine($"Password: {this.Password}");
        }
    }
}

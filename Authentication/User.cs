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

        public virtual string GenerateUsername(string firstName, string lastName)
        {
            string username = (firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName)
                              + (lastName.Length >= 2 ? lastName.Substring(0, 2) : lastName);
            return username.ToLower();
        }

        public virtual void EditUser(string newFirstName, string newLastName, string newPassword)
        {
            FirstName = newFirstName;
            LastName = newLastName;
            Password = newPassword;
            Username = GenerateUsername(newFirstName, newLastName);
        }

        public virtual void ShowUserDetail()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Password: {Password}");
        }
    }

    public class Admin : User
    {
        public Admin(string firstname, string lastname, string password) : base(firstname, lastname, password)
        {
            // No need to reassign the properties from the base class, as they are already inherited
        }

        public Admin(string username, string password) : base(" "," ", password)
        {
            Username = username;
        } 

        public override string GenerateUsername(string firstName, string lastName)
        {
            string username = (firstName.Length >= 2 ? firstName.Substring(0, 2) : firstName)
                              + (lastName.Length >= 2 ? lastName.Substring(0, 2) : lastName);
            return username.ToLower();
        }

        public override void EditUser(string newFirstName, string newLastName, string newPassword)
        {
            base.EditUser(newFirstName, newLastName, newPassword);
            Username = GenerateUsername(newFirstName, newLastName);
        }

        public override void ShowUserDetail()
        {
            base.ShowUserDetail();
        }

    }
}

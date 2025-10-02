using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace PersonApp
{
    class Person
    {
        private string firstName { get; set; }
        private string lastName { get; set; }
        private int Age { get; set; }
        private string Gender { get; set; }
        private bool Married { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        private Address Address { get; set; }
        private List<string> Hobbies { get; set; }

        // Default constructor
        public Person()
        {
            this.firstName = "Peter";
            this.lastName = "Parker";
            this.Age = 69;
            this.Gender = "Male";
            this.Married = false;
            this.Email = "peter.parker@example.com";
            this.Phone = "123-456-7890";
            this.Address = new Address("20 Ingram Street", "Forest Hills", "NY", "11375");
            this.Hobbies = new List<string>() { "Photography", "Reading" };
        }

        // Overloaded constructor
        public Person(string firstName, string lastName, int age, string gender, bool married,
                      string email, string phone, Address address, List<string> hobbies)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.Age = age;
            this.Gender = gender;
            this.Married = married;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
            this.Hobbies = hobbies;
        }

        public override string ToString()
        {
            return $"First Name: {firstName}\n" +
                   $"Last Name: {lastName}\n" +
                   $"Age: {Age}\n" +
                   $"Gender: {Gender}\n" +
                   $"Married: {Married}\n" +
                   $"Email: {Email}\n" +
                   $"Phone: {Phone}\n" +
                   $"Address: {Address}\n" +
                   $"Hobbies: {string.Join(", ", Hobbies)}";
        }
        public static Person FromJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Person>(jsonData);
        }
    }
}

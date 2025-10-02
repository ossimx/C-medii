using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PersonApp
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public bool Married { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public List<string> Hobbies { get; set; }

        public Person()
        {
            FirstName = "Peter";
            LastName = "Parker";
            Age = 69;
            Gender = "Male";
            Married = false;
            Email = "peter.parker@example.com";
            Phone = "123-456-7890";
            Address = new Address("20 Ingram Street", "Forest Hills", "NY", "11375");
            Hobbies = new List<string> { "Photography", "Reading" };
        }

        public Person(string firstName, string lastName, int age, string gender, bool married,
                      string email, string phone, Address address, List<string> hobbies)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Married = married;
            Email = email;
            Phone = phone;
            Address = address;
            Hobbies = hobbies;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}\n" +
                   $"Last Name: {LastName}\n" +
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
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Person>(jsonData, options);
        }
    }
}

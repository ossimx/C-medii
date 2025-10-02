using System;
using System.Collections.Generic;

namespace PersonApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Address addr = new Address("123 Main St", "New York", "NY", "10001");
            List<string> hobbies = new List<string>() { "Music", "Dance", "Traveling" };

            // Create a Person
            Person testPerson = new Person("Michael", "Jackson", 50, "Male", true,
                                           "mj@pop.com", "987-654-3210", addr, hobbies);
            Console.WriteLine("=== Person ===");
            Console.WriteLine(testPerson.ToString());

            Console.WriteLine("\n=== Employee ===");
            // Create an Employee
            Employee emp = new Employee("Tony", "Stark", 48, "Male", true,
                                        "tony.stark@starkindustries.com", "555-999-1234", addr,
                                        new List<string>() { "Engineering", "Flying", "Inventing" },
                                        "E1001", "CEO", "R&D", 2000000.00);

            Console.WriteLine(emp.ToString());*/
            Console.WriteLine("=== Load Person from JSON ===");
            Person bruce = Person.FromJsonFile("person.json");
            Console.WriteLine(bruce.ToString());

            Console.WriteLine("\n=== Load Employee from JSON ===");
            Employee tony = Employee.FromJsonFile("employee.json");
            Console.WriteLine(tony.ToString());
        }
    }
}

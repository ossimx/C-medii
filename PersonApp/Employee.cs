using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PersonApp
{
    class Employee : Person
    {
        public string EmployeeId { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Employee(string firstName, string lastName, int age, string gender, bool married,
                        string email, string phone, Address address, List<string> hobbies,
                        string employeeId, string jobTitle, string department, double salary)
            : base(firstName, lastName, age, gender, married, email, phone, address, hobbies)
        {
            this.EmployeeId = employeeId;
            this.JobTitle = jobTitle;
            this.Department = department;
            this.Salary = salary;
        }
        public Employee() { }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"Employee ID: {EmployeeId}\n" +
                   $"Job Title: {JobTitle}\n" +
                   $"Department: {Department}\n" +
                   $"Salary: ${Salary:N2}";
        }
        public new static Employee FromJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<Employee>(jsonData, options);
        }

    }
}

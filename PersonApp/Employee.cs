using System;
using System.IO;
using System.Text.Json;

namespace PersonApp
{
    public class Employee : Person
    {
        public string EmployeeId { get; set; }
        public double BonusPercentage { get; set; }
        public Company Company { get; set; }

        public virtual double Salary
        {
            get
            {
                if (Company == null) return 0;
                return Company.MinimumWage * BonusPercentage;
            }
        }

        public Employee() { }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"Employee ID: {EmployeeId}\n" +
                   $"Bonus Percentage: {BonusPercentage}\n" +
                   $"Salary: ${Salary:N2}\n";
        }

        public new static Employee FromJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Employee>(jsonData, options);
        }
    }
}

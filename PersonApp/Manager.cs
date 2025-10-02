using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PersonApp
{
    public sealed class Manager : Employee
    {
        public Employee[] Employees { get; set; }

        public override double Salary
        {
            get
            {
                if (Company == null) return 0;
                int count = Employees?.Length ?? 0;
                return Company.MinimumWage * BonusPercentage * (count * 0.3);
            }
        }

        public Manager() { }

        public override string ToString()
        {
            string employeesStr = Employees == null ? "No employees assigned" :
                string.Join("\n", Employees.Select(e => e.ToString()));

            return base.ToString() + "\n--- Employees under Manager ---\n" + employeesStr;
        }

        public new static Manager FromJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Manager>(jsonData, options);
        }
    }
}

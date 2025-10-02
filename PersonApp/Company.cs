using PersonApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PersonApp
{
    public class Company
    {
        public string Name { get; set; }
        public double MinimumWage { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Manager> Managers { get; set; } // matches JSON array
        public Director Director { get; set; }
        public double directorWage {  get; set; }

        public Company() { }

        public override string ToString()
        {
            string employeesStr = Employees == null ? "" :
                string.Join("\n---\n", Employees);

            string managersStr = (Managers == null || Managers.Count == 0) ? "No managers" :
                string.Join("\n\n", Managers.Select(m => m.ToString()));

            string directorStr = Director == null
    ? "No director assigned"
    : $"[DIRECTOR]\n{Director.FirstName} {Director.LastName}\n" +
      $"Age: {Director.Age}\n" +
      $"Salary (calculated): ${directorWage:N2}";

            return $"=== Company Info ===\n" +
                   $"Name: {Name}\n" +
                   $"Minimum Wage: {MinimumWage}\n\n" +
                   $"=== Director ===\n{directorStr}\n\n" +
                   $"=== Manager ===\n{managersStr}\n\n" +
                   $"=== Employees ===\n{employeesStr}";
        }

        public static Company FromJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Company company = JsonSerializer.Deserialize<Company>(jsonData, options);
            if (company.Managers != null)
            {
                foreach (var manager in company.Managers)
                {
                    manager.Company = company;
                    if (manager.Employees != null)
                    {
                        foreach (var emp in manager.Employees)
                        {
                            emp.Company = company;
                        }
                    }
                }
            }

            // Wire standalone employees
            if (company.Employees != null)
            {
                foreach (var emp in company.Employees)
                {
                    emp.Company = company;
                }
            }
            int totalEmployees = 0;
            if (company.Managers != null)
            {
                foreach (var manager in company.Managers)
                {
                    if (manager != null && manager.Employees != null)
                    {
                        totalEmployees += manager.Employees.Length;
                    }
                }
            }
            // Calculate DirectorWage here
            company.directorWage = company.MinimumWage * totalEmployees * 2; // weight 2


            return company;
        }

    }
 
}

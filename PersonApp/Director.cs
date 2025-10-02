using System;
using System.IO;
using System.Text.Json;

namespace PersonApp
{
    public sealed class Director : Employee
    {
        private static Director _instance;

        public Director()
        {
            if (_instance != null)
            {
                throw new InvalidOperationException("Only one instance of Director is allowed!");
            }
            _instance = this;
        }
        public static Director Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Director();
                }
                return _instance;
            }
        }

        public override string ToString()
        {
            return "[DIRECTOR]\n" + base.ToString();
        }

        public new static Director FromJsonFile(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var director = JsonSerializer.Deserialize<Director>(jsonData, options);

            // enforce singleton
            _instance = director;
            return _instance;
        }
    }

}

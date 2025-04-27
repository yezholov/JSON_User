using Newtonsoft.Json;
using System;
using System.IO;

class Program
{
    // Define a class to match the JSON structure
    public class User
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
    }

    static void Main(string[] args)
    {
        // Path to the local JSON file
        string filePath = "users.json";

        // Read the JSON data from the file
        string jsonResponse = File.ReadAllText(filePath);

        // Deserialize the JSON into a list of C# objects
        List<User>? users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

        // Adding a new user
        User newUser = new User
        {
            Name = "Alice Smith",
            Age = 33,
            City = "Vilnius"
        };

        users?.Add(newUser);

        // Serialize updated list back to JSON
        string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);

        // Save to file
        File.WriteAllText(filePath, updatedJson);

        if (users != null)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Age: {user.Age}");
                Console.WriteLine($"City: {user.City}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Failed to deserialize the JSON data into a User object.");
        }
    }
}

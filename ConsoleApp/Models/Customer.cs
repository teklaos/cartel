using System.Text.Json;

namespace ConsoleApp.models;

public class Customer {
    private static IList<Customer> _customers = new List<Customer>();
    public static IList<Customer> Customers {
        get => new List<Customer>(_customers);
        private set => _customers = value;
    }

    public Customer() => _customers.Add(this);
    
    public static void Serialize() {
        string fileName = "Customers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Customers, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Customers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Customers = JsonSerializer.Deserialize<List<Customer>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
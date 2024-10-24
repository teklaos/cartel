using System.Text.Json;

namespace ConsoleApp.models;

public class Customer {
    public static IEnumerable<Customer> _customers { get; private set; } = new List<Customer>();

    public Customer() {
        ArgumentNullException.ThrowIfNull(this);
        _customers = _customers.Append(this);
    }

    public static int GetCustomersCount() {
        return _customers.Count();
    }
    
    public static void Serialize() {
        string fileName = "Customers.json";
        string jsonString = JsonSerializer.Serialize(_customers, ISerializable.jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Customers.json";
        string jsonString = File.ReadAllText(fileName);
        _customers = JsonSerializer.Deserialize<List<Customer>>(jsonString) ?? new List<Customer>();
    }
}
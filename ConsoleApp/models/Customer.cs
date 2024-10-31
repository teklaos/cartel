using System.Text.Json;

namespace ConsoleApp.models;

public class Customer {
    public static IEnumerable<Customer> _customers { get; private set; } = new List<Customer>();

    public Customer() {
        AddCustomer();
    }

    private void AddCustomer() {
        try {
            ArgumentNullException.ThrowIfNull(this);
            _customers = _customers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Customers.json";
        string jsonString = JsonSerializer.Serialize(_customers, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Customers.json";
        string jsonString = File.ReadAllText(fileName);
        _customers = JsonSerializer.Deserialize<List<Customer>>(jsonString) ?? new List<Customer>();
    }
}
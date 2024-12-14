using System.Text.Json;

namespace ConsoleApp.models;

public class Customer {
    private static IEnumerable<Customer> _customers = new List<Customer>();
    public static IEnumerable<Customer> Customers {
        get => new List<Customer>(_customers);
        private set => _customers = value;
    }

    public Customer() => Customers = Customers.Append(this);

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static void Serialize() {
        string fileName = "Customers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Customers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Customers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Customers = JsonSerializer.Deserialize<List<Customer>>(jsonString) ?? new List<Customer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
using System.Text.Json;

namespace ConsoleApp.models;

public class DistributorCustomer {
    public static IEnumerable<DistributorCustomer> _distributorsCustomers { get; private set; } = new List<DistributorCustomer>();
    public DateTime DealStartDate { get; private set; }
    public int AmountOfProduct { get; private set; }
    public DateTime? DealEndDate { get; private set; }

    public DistributorCustomer(DateTime dealStartDate, int amountOfProduct, DateTime? dealEndDate) {
        
        if (amountOfProduct < 0)
            throw new ArgumentException("Amount of product cannot be < 0");
        
        DealStartDate = dealStartDate;
        AmountOfProduct = amountOfProduct;
        DealEndDate = dealEndDate;
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static void Serialize() {
        string fileName = "DistributorsCustomers.json";
        try {
            string jsonString = JsonSerializer.Serialize(_distributorsCustomers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "DistributorsCustomers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _distributorsCustomers = JsonSerializer.Deserialize<List<DistributorCustomer>>(jsonString) ?? new List<DistributorCustomer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
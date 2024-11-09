using System.Text.Json;

namespace ConsoleApp.models;

public class DistributorCustomer {
    public static IEnumerable<DistributorCustomer> DistributorsCustomers { get; private set; } = new List<DistributorCustomer>();
    public DateTime DealStartDate { get; private set; }
    public int PoundsOfProduct { get; private set; }
    public DateTime? DealEndDate { get; private set; }

    public DistributorCustomer(DateTime dealStartDate, int poundsOfProduct, DateTime? dealEndDate) {
        if (poundsOfProduct < 0)
            throw new ArgumentException("Amount of product cannot be negative.");
        
        DealStartDate = dealStartDate;
        PoundsOfProduct = poundsOfProduct;
        DealEndDate = dealEndDate;
        DistributorsCustomers = DistributorsCustomers.Append(this);
    }
    
    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static void Serialize() {
        string fileName = "DistributorsCustomers.json";
        try {
            string jsonString = JsonSerializer.Serialize(DistributorsCustomers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "DistributorsCustomers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            DistributorsCustomers = JsonSerializer.Deserialize<List<DistributorCustomer>>(jsonString) ?? new List<DistributorCustomer>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
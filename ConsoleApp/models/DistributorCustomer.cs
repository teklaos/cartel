using System.Text.Json;

namespace ConsoleApp.models;

public class DistributorCustomer {
    public static IEnumerable<DistributorCustomer> _distributorsCustomers { get; private set; } = new List<DistributorCustomer>();
    public DateTime DealStartDate { get; set; }
    public int AmountOfProduct { get; set; }
    public DateTime? DealEndDate { get; set; }

    public DistributorCustomer(DateTime dealStartDate, int amountOfProduct, DateTime? dealEndDate) {
        this.DealStartDate = dealStartDate;
        this.AmountOfProduct = amountOfProduct;
        this.DealEndDate = dealEndDate;
        
        ArgumentNullException.ThrowIfNull(this);
        _distributorsCustomers = _distributorsCustomers.Append(this);
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static void Serialize() {
        string fileName = "DistributorsCustomers.json";
        string jsonString = JsonSerializer.Serialize(_distributorsCustomers, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "DistributorsCustomers.json";
        string jsonString = File.ReadAllText(fileName);
        _distributorsCustomers = JsonSerializer.Deserialize<List<DistributorCustomer>>(jsonString) ?? new List<DistributorCustomer>();
    }
}
using System.Text.Json;

namespace ConsoleApp.models;

public class DistributorCustomer {
    public static IEnumerable<DistributorCustomer> _distributorsCustomers { get; private set; } = new List<DistributorCustomer>();
    public DateTime DealStartDate { get; private set; }
    public int AmountOfProduct { get; private set; }
    public DateTime? DealEndDate { get; private set; }

    public DistributorCustomer(DateTime dealStartDate, int amountOfProduct, DateTime? dealEndDate) {
        DealStartDate = dealStartDate;
        AmountOfProduct = amountOfProduct;
        DealEndDate = dealEndDate;
        AddDistributorCustomer();
    }

    private void AddDistributorCustomer() {
        try {
            ArgumentNullException.ThrowIfNull(DealStartDate, "Deal start date");
            ArgumentOutOfRangeException.ThrowIfNegative(AmountOfProduct, "Amount of product");
            ArgumentNullException.ThrowIfNull(DealEndDate, "Deal end date");
            ArgumentNullException.ThrowIfNull(this);
            _distributorsCustomers = _distributorsCustomers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
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
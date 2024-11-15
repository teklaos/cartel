using System.Text.Json;

namespace ConsoleApp.models;

public class DistributorCustomer {
    private static IEnumerable<DistributorCustomer> _distributorsCustomers = new List<DistributorCustomer>();
    public static IEnumerable<DistributorCustomer> DistributorsCustomers {
        get => new List<DistributorCustomer>(_distributorsCustomers);
        private set => _distributorsCustomers = value;
    }
    public DateTime DealStartDate { get; private set; }
    public int PoundsOfProduct { get; private set; }
    public DateTime? DealEndDate { get; private set; }

    public DistributorCustomer(DateTime dealStartDate, int poundsOfProduct, DateTime? dealEndDate) {
        if (poundsOfProduct < 0)
            throw new ArgumentException("Pounds of product cannot be negative.");
        if (dealStartDate < new DateTime(1890, 1, 1))
            throw new ArgumentException("Deal start date cannot be earlier than year 1890.");
        if (dealStartDate > DateTime.Now)
            throw new ArgumentException("Deal start date cannot be in the future.");
        if (dealEndDate.HasValue) {
            if (dealEndDate.Value < dealStartDate)
                throw new ArgumentException("Deal end date cannot be earlier than the start date.");
            if (dealEndDate.Value > DateTime.Now)
                throw new ArgumentException("Deal end date cannot be in the future.");
        }
        
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

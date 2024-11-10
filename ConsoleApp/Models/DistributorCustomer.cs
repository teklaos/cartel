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

        ValidateDealStartDate(dealStartDate);
        ValidateDealEndDate(dealStartDate, dealEndDate);
        
        DealStartDate = dealStartDate;
        PoundsOfProduct = poundsOfProduct;
        DealEndDate = dealEndDate;
        DistributorsCustomers = DistributorsCustomers.Append(this);
    }

    private static void ValidateDealStartDate(DateTime startDate) {
        if (startDate < new DateTime(2000, 1, 1)) {
            throw new ArgumentException("Invalid DateTime, start of the deal cannot be earlier than year 2000.");
        }
        
        if (startDate > DateTime.Now) {
            throw new ArgumentException("Deal start date cannot be in the future.");
        }
    }

    private static void ValidateDealEndDate(DateTime startDate, DateTime? endDate) {
        if (endDate.HasValue) {
            if (endDate.Value < startDate) {
                throw new ArgumentException("Deal end date cannot be earlier than the start date.");
            }

            if (endDate.Value > DateTime.Now) {
                throw new ArgumentException("Deal end date cannot be in the future.");
            }
        }
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

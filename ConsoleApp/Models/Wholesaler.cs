using System.Text.Json;

namespace ConsoleApp.models;

public class Wholesaler : Customer {
    public static IEnumerable<Wholesaler> _wholesalers { get; private set; } = new List<Wholesaler>();
    public double CommissionPercentage { get; private set; }
    public int MonthlyCustomers { get; private set; }

    public Wholesaler(double commissionPercentage, int monthlyCustomers) : base() {
        if (commissionPercentage < 0)
            throw new ArgumentOutOfRangeException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentOutOfRangeException("Monthly customers cannot be negative.");

        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
        _wholesalers = _wholesalers.Append(this);
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Wholesalers.json";
        try {
            string jsonString = JsonSerializer.Serialize(_wholesalers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Wholesalers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _wholesalers = JsonSerializer.Deserialize<List<Wholesaler>>(jsonString) ?? new List<Wholesaler>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
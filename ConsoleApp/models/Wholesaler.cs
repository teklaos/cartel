using System.Text.Json;

namespace ConsoleApp.models;

public class Wholesaler : Customer {
    public static IEnumerable<Wholesaler> _wholesalers { get; private set; } = new List<Wholesaler>();
    public double CommissionPercentage { get; private set; }
    public int MonthlyCustomers { get; private set; }

    public Wholesaler(double commissionPercentage, int monthlyCustomers):
    base() {
        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
        AddWholesaler();
    }

    private void AddWholesaler() {
        try {
            ArgumentOutOfRangeException.ThrowIfNegative(CommissionPercentage, "Commission percentage");
            ArgumentOutOfRangeException.ThrowIfNegative(MonthlyCustomers, "Monthly customers");
            ArgumentNullException.ThrowIfNull(this);
            _wholesalers = _wholesalers.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Wholesalers.json";
        string jsonString = JsonSerializer.Serialize(_wholesalers, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static new void Deserialize() {
        string fileName = "Wholesalers.json";
        string jsonString = File.ReadAllText(fileName);
        _wholesalers = JsonSerializer.Deserialize<List<Wholesaler>>(jsonString) ?? new List<Wholesaler>();
    }
}
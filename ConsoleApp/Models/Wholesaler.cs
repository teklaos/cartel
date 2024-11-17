using System.Text.Json;

namespace ConsoleApp.models;

public class Wholesaler : Customer {
    private static IEnumerable<Wholesaler> _wholesalers = new List<Wholesaler>();
    public static IEnumerable<Wholesaler> Wholesalers {
        get => new List<Wholesaler>(_wholesalers);
        private set => _wholesalers = value;
    }
    public double CommissionPercentage { get; private set; }
    public int MonthlyCustomers { get; private set; }

    public Wholesaler(double commissionPercentage, int monthlyCustomers) : base() {
        if (commissionPercentage < 0)
            throw new ArgumentException("Commission percentage cannot be negative.");
        if (monthlyCustomers < 0)
            throw new ArgumentException("Amount of monthly customers cannot be negative.");

        CommissionPercentage = commissionPercentage;
        MonthlyCustomers = monthlyCustomers;
        Wholesalers = Wholesalers.Append(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static new void Serialize() {
        string fileName = "Wholesalers.json";
        try {
            string jsonString = JsonSerializer.Serialize(Wholesalers, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Wholesalers.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Wholesalers = JsonSerializer.Deserialize<List<Wholesaler>>(jsonString) ?? new List<Wholesaler>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
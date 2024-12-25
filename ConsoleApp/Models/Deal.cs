using System.Text.Json;

namespace ConsoleApp.models;

public class Deal {
    private static IList<Deal> _deals = new List<Deal>();
    public static IList<Deal> Deals {
        get => new List<Deal>(_deals);
        private set => _deals = value;
    }
    public DateTime StartDate { get; private set; }
    public int PoundsOfProduct { get; private set; }
    public DateTime? EndDate { get; private set; }

    public Deal(DateTime startDate, int poundsOfProduct, DateTime? endDate) {
        if (poundsOfProduct < 0)
            throw new ArgumentException("Pounds of product cannot be negative.");
        if (startDate < new DateTime(1890, 1, 1))
            throw new ArgumentException("Deal start date cannot be earlier than year 1890.");
        if (startDate > DateTime.Now)
            throw new ArgumentException("Deal start date cannot be in the future.");
        if (endDate.HasValue) {
            if (endDate.Value < startDate)
                throw new ArgumentException("Deal end date cannot be earlier than the start date.");
            if (endDate.Value > DateTime.Now)
                throw new ArgumentException("Deal end date cannot be in the future.");
        }

        StartDate = startDate;
        PoundsOfProduct = poundsOfProduct;
        EndDate = endDate;
        _deals.Add(this);
    }
    
    public static void Serialize() {
        string fileName = "Deals.json";
        try {
            string jsonString = JsonSerializer.Serialize(Deals, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Deals.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Deals = 
                JsonSerializer.Deserialize<List<Deal>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}

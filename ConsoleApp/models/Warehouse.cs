namespace ConsoleApp.models;

public class Warehouse {
    public static IEnumerable<Warehouse> _warehouses { get; private set; } = new List<Warehouse>();
    public string Location { get; set; } = null!;
    public int MaxCapacity { get; set; }

    public Warehouse(string location, int maxCapacity) {
        this.Location = location;
        this.MaxCapacity = maxCapacity;
        _warehouses = _warehouses.Append(this);
    }
}
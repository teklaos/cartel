namespace ConsoleApp;

public class Warehouse {
    public string Location { get; set; } = null!;
    public int MaxCapacity { get; set; }

    public Warehouse(string location, int maxCapacity) {
        this.Location = location;
        this.MaxCapacity = maxCapacity;
    }
}
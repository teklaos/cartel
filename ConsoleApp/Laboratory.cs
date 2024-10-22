namespace ConsoleApp;

public class Laboratory {
    public string Location { get; set; } = null!;
    public static int MaxPoundsPerCook { get; } = 50;

    public Laboratory(string location) {
        this.Location = location;
    }
}
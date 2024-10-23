namespace ConsoleApp;

public class Laboratory {
    private static IEnumerable<Laboratory> _laboratories = new List<Laboratory>();
    public string Location { get; set; } = null!;
    public static int MaxPoundsPerCook { get; } = 50;

    public Laboratory(string location) {
        this.Location = location;
        _laboratories = _laboratories.Append(this);
    }
}
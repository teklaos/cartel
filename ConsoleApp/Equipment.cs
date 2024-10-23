namespace ConsoleApp;

public class Equipment {
    private static IEnumerable<Equipment> _equipment = new List<Equipment>();
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;

    public Equipment(string type, string name, string model) {
        this.Type = type;
        this.Name = name;
        this.Model = model;
        _equipment = _equipment.Append(this);
    }
}
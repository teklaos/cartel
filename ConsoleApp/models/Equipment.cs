namespace ConsoleApp.models;

public class Equipment {
    public static IEnumerable<Equipment> _equipment { get; private set; } = new List<Equipment>();
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
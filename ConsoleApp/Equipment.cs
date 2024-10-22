namespace ConsoleApp;

public class Equipment {
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;

    public Equipment(string type, string name, string model) {
        this.Type = type;
        this.Name = name;
        this.Model = model;
    }
}
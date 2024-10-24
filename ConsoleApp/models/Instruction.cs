using System.Text.Json;

namespace ConsoleApp.models;

public enum ActionAttribute {
    Add,
    Stir,
    Combine
}

public class Instruction {
    public static IEnumerable<Instruction> _instructions { get; private set; } = new List<Instruction>();
    public ActionAttribute Action { get; set; }

    public Instruction(ActionAttribute action) {
        this.Action = action;
        _instructions = _instructions.Append(this);
    }
    
    public static void Serialize() {
        string fileName = "Products.json";
        string jsonString = JsonSerializer.Serialize(_instructions, ISerializable.jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Products.json";
        string jsonString = File.ReadAllText(fileName);
        _instructions = JsonSerializer.Deserialize<List<Instruction>>(jsonString) ?? new List<Instruction>();
    }
}
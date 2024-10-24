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

        ArgumentNullException.ThrowIfNull(this);
        _instructions = _instructions.Append(this);
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Instructions.json";
        string jsonString = JsonSerializer.Serialize(_instructions, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Instructions.json";
        string jsonString = File.ReadAllText(fileName);
        _instructions = JsonSerializer.Deserialize<List<Instruction>>(jsonString) ?? new List<Instruction>();
    }
}
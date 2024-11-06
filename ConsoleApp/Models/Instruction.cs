using System.Text.Json;

namespace ConsoleApp.models;

public enum ActionAttribute {
    Add,
    Stir,
    Combine
}

public class Instruction {
    public static IEnumerable<Instruction> _instructions { get; private set; } = new List<Instruction>();
    public ActionAttribute Action { get; private set; }

    public Instruction(ActionAttribute action) {
        Action = action;
        _instructions = _instructions.Append(this);
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Instructions.json";
        try {
            string jsonString = JsonSerializer.Serialize(_instructions, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Instructions.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _instructions = JsonSerializer.Deserialize<List<Instruction>>(jsonString) ?? new List<Instruction>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
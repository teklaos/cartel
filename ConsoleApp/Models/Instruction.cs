using System.Text.Json;

namespace ConsoleApp.models;

public enum ActionAttribute {
    Add,
    Stir,
    Combine
}

public class Instruction {
    public static IEnumerable<Instruction> Instructions { get; private set; } = new List<Instruction>();
    public ActionAttribute Action { get; private set; }

    public Instruction(ActionAttribute action) {
        Action = action;
        Instructions = Instructions.Append(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
    
    public static void Serialize() {
        string fileName = "Instructions.json";
        try {
            string jsonString = JsonSerializer.Serialize(Instructions, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Instructions.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Instructions = JsonSerializer.Deserialize<List<Instruction>>(jsonString) ?? new List<Instruction>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
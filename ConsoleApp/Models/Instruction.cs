using System.Text.Json;

namespace ConsoleApp.models;

public class Instruction {
    private static IList<Instruction> _instructions = new List<Instruction>();
    public static IList<Instruction> Instructions {
        get => new List<Instruction>(_instructions);
        private set => _instructions = value;
    }
    public string Action { get; private set; }

    public Instruction(string action) {
        Action = action;
        _instructions.Add(this);
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
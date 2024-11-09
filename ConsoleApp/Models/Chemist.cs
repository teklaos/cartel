using System.Text.Json;

namespace ConsoleApp.models;

public class Chemist : CartelMember {
    public static IEnumerable<Chemist> Chemists { get; private set; } = new List<Chemist>();
    public int PoundsCooked { get; private set; }

    public Chemist(string name, int trustLevel, IEnumerable<string> rulesToFollow, int poundsCooked):
    base(name, trustLevel, rulesToFollow) {
        if (poundsCooked < 0)
            throw new ArgumentException("Cooked pounds cannot be negative.");
        
        PoundsCooked = poundsCooked;
        Chemists = Chemists.Append(this);
    }

    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

    public static new void Serialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = JsonSerializer.Serialize(Chemists, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Chemists = JsonSerializer.Deserialize<List<Chemist>>(jsonString) ?? new List<Chemist>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
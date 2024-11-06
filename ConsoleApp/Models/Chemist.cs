using System.Text.Json;

namespace ConsoleApp.models;

public class Chemist : CartelMember {
    public static IEnumerable<Chemist> _chemists { get; private set; } = new List<Chemist>();
    public int PoundsCooked { get; private set; }

    public Chemist(string name, int trustLevel, IEnumerable<string> rulesToFollow, int poundsCooked):
    base(name, trustLevel, rulesToFollow) {
        if (poundsCooked < 0)
            throw new ArgumentException("PoundsCooked cannot be < 0");
        
        PoundsCooked = poundsCooked;
        _chemists = _chemists.Append(this);
    }
    

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = JsonSerializer.Serialize(_chemists, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static new void Deserialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _chemists = JsonSerializer.Deserialize<List<Chemist>>(jsonString) ?? new List<Chemist>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
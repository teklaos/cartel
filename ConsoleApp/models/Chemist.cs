using System.Text.Json;

namespace ConsoleApp.models;

public class Chemist : CartelMember {
    public static IEnumerable<Chemist> _chemists { get; private set; } = new List<Chemist>();
    public int PoundsCooked { get; private set; }

    public Chemist(string name, int trustLevel, IEnumerable<string> rulesToFollow, int poundsCooked):
    base(name, trustLevel, rulesToFollow) {
        PoundsCooked = poundsCooked;
        AddChemist();
    }

    private void AddChemist() {
        try {
            ArgumentOutOfRangeException.ThrowIfNegative(PoundsCooked, "Pounds cooked");
            ArgumentNullException.ThrowIfNull(this);
            _chemists = _chemists.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};

    public static new void Serialize() {
        string fileName = "Chemists.json";
            string jsonString = JsonSerializer.Serialize(_chemists, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
    }

    public static new void Deserialize() {
        string fileName = "Chemists.json";
        string jsonString = File.ReadAllText(fileName);
        _chemists = JsonSerializer.Deserialize<List<Chemist>>(jsonString) ?? new List<Chemist>();
    }
}
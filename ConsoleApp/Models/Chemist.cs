using System.Text.Json;

namespace ConsoleApp.models;

public class Chemist : CartelMember {
    private static IList<Chemist> _chemists = new List<Chemist>();
    public static IList<Chemist> Chemists {
        get => new List<Chemist>(_chemists);
        private set => _chemists = value;
    }
    public int PoundsCooked { get; private set; }

    public Chemist(string name, int trustLevel, IList<string> rulesToFollow, int poundsCooked) :
    base(name, trustLevel, rulesToFollow) {
        if (poundsCooked < 0)
            throw new ArgumentException("Cooked pounds cannot be negative.");

        PoundsCooked = poundsCooked;
        _chemists.Add(this);
    }
    
    public new static void Serialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = JsonSerializer.Serialize(Chemists, AppConfig.JsonSerializerOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public new static void Deserialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Chemists = JsonSerializer.Deserialize<List<Chemist>>(jsonString) ?? new List<Chemist>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
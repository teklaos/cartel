using System.Text.Json;

namespace ConsoleApp.models;

public class Recipe {
    public static IEnumerable<Recipe> _recipes { get; private set; } = new List<Recipe>();
    private static readonly int AmountOfInstructions = 55;
    public int Complexity {
        get => AmountOfInstructions/10;
    }

    public Recipe() {
        _recipes = _recipes.Append(this);
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Recipes.json";
        try {
            string jsonString = JsonSerializer.Serialize(_recipes, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Recipes.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            _recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonString) ?? new List<Recipe>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
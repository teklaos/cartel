using System.Text.Json;

namespace ConsoleApp.models;

public class Recipe {
    public static IEnumerable<Recipe> _recipes { get; private set; } = new List<Recipe>();
    public int Complexity { get; set; }

    public Recipe(int complexity) {
        this.Complexity = complexity;

        ArgumentNullException.ThrowIfNull(this);
        _recipes.Append(this);
    }
    
    public static void Serialize() {
        string fileName = "Recipes.json";
        string jsonString = JsonSerializer.Serialize(_recipes, ISerializable.jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Recipes.json";
        string jsonString = File.ReadAllText(fileName);
        _recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonString) ?? new List<Recipe>();
    }
}
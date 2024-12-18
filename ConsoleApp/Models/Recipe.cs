using System.Text.Json;

namespace ConsoleApp.models;

public class Recipe {
    private static IList<Recipe> _recipes = new List<Recipe>();
    public static IList<Recipe> Recipes {
        get => new List<Recipe>(_recipes);
        private set => _recipes = value;
    }
    private readonly int _amountOfInstructions = 55;
    public int Complexity { get => _amountOfInstructions / 10; }

    public Recipe() => _recipes.Add(this);
    
    public static void Serialize() {
        string fileName = "Recipes.json";
        try {
            string jsonString = JsonSerializer.Serialize(Recipes, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Recipes.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
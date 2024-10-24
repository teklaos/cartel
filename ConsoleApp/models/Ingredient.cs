using System.Text.Json;

namespace ConsoleApp.models;

public enum StateAttribute {
    Gas,
    Liquid,
    Solid
}

public class Ingredient {
    public static IEnumerable<Ingredient> _ingredients { get; private set; } = new List<Ingredient>();
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string ChemicalFormula { get; set; } = null!;
    public StateAttribute State { get; set; }

    public Ingredient(string name, int price, string chemicalFormula, StateAttribute state) {
        this.Name = name;
        this.Price = price;
        this.ChemicalFormula = chemicalFormula;
        this.State = state;

        ArgumentNullException.ThrowIfNull(this);
        _ingredients = _ingredients.Append(this);
    }
    
    private readonly static JsonSerializerOptions _jsonOptions = new() {WriteIndented = true};
    
    public static void Serialize() {
        string fileName = "Ingredients.json";
        string jsonString = JsonSerializer.Serialize(_ingredients, _jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }

    public static void Deserialize() {
        string fileName = "Ingredients.json";
        string jsonString = File.ReadAllText(fileName);
        _ingredients = JsonSerializer.Deserialize<List<Ingredient>>(jsonString) ?? new List<Ingredient>();
    }
}
using System.Text.Json;

namespace ConsoleApp.models;

public enum StateAttribute {
    Gas,
    Liquid,
    Solid
}

public class Ingredient {
    public static IEnumerable<Ingredient> _ingredients { get; private set; } = new List<Ingredient>();
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string ChemicalFormula { get; private set; }
    public StateAttribute State { get; private set; }

    public Ingredient(string name, int price, string chemicalFormula, StateAttribute state) {
        Name = name;
        Price = price;
        ChemicalFormula = chemicalFormula;
        State = state;
        AddIngredient();
    }

    private void AddIngredient() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Name, "Name");
            ArgumentOutOfRangeException.ThrowIfNegative(Price, "Price");
            ArgumentException.ThrowIfNullOrWhiteSpace(ChemicalFormula, "Chemical formula");
            ArgumentNullException.ThrowIfNull(State, "State");
            ArgumentNullException.ThrowIfNull(this);
            _ingredients = _ingredients.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
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
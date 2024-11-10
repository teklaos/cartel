using System.Text.Json;

namespace ConsoleApp.models;

public enum StateAttribute {
    Gas,
    Liquid,
    Solid
}

public class Ingredient {
    public static IEnumerable<Ingredient> Ingredients { get; private set; } = new List<Ingredient>();
    public string Name { get; private set; }
    public int Price { get; private set; }
    public string ChemicalFormula { get; private set; }
    public StateAttribute State { get; private set; }

    public Ingredient(string name, int price, string chemicalFormula, StateAttribute state) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");
        if (string.IsNullOrWhiteSpace(chemicalFormula))
            throw new ArgumentException("Chemical formula cannot be null or whitespace.");

        Name = name;
        Price = price;
        ChemicalFormula = chemicalFormula;
        State = state;
        Ingredients = Ingredients.Append(this);
    }
    
    private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
    
    public static void Serialize() {
        string fileName = "Ingredients.json";
        try {
            string jsonString = JsonSerializer.Serialize(Ingredients, _jsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Ingredients.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Ingredients = JsonSerializer.Deserialize<List<Ingredient>>(jsonString) ?? new List<Ingredient>();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
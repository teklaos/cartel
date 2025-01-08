using System.Text.Json;

namespace ConsoleApp.models;

public class SupplyChain {
    private static IList<SupplyChain> _supplyChains = new List<SupplyChain>();
    public static IList<SupplyChain> SupplyChains {
        get => new List<SupplyChain>(_supplyChains);
        private set => _supplyChains = value;
    }
    public string Name { get; private set; }
    public int TransitionTime { get; private set; }

    private IList<Ingredient> _associatedIngredients = new List<Ingredient>();
    public IList<Ingredient> AssociatedIngredients {
        get => new List<Ingredient>(_associatedIngredients);
        private set => _associatedIngredients = value;
    }

    public SupplyChain(string name, int transitionTime) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (transitionTime < 0)
            throw new ArgumentException("Transition time cannot be negative.");

        Name = name;
        TransitionTime = transitionTime;

        _supplyChains.Add(this);
    }

    public void AddIngredient(Ingredient ingredient) {
        _associatedIngredients.Add(ingredient);
        ingredient.AddSupplyChainInternally(this);
    }

    public void RemoveIngredient(Ingredient ingredient) {
        if (!_associatedIngredients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
        ingredient.RemoveSupplyChainInternally();
    }

    public void EditIngredient(Ingredient oldIngredient, Ingredient newIngredient) {
        RemoveIngredient(oldIngredient);
        AddIngredient(newIngredient);
    }

    public void AddIngredientInternally(Ingredient ingredient) =>
        _associatedIngredients.Add(ingredient);

    public void RemoveIngredientInternally(Ingredient ingredient) {
        if (!_associatedIngredients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
    }

    public static void Serialize() {
        string fileName = "SupplyChains.json";
        try {
            string jsonString = JsonSerializer.Serialize(SupplyChains, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "SupplyChains.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            SupplyChains = JsonSerializer.Deserialize<List<SupplyChain>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
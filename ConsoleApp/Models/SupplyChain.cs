using System.Text.Json;

namespace ConsoleApp.models;

public class SupplyChain {
    private static IList<SupplyChain> _supplyChains = new List<SupplyChain>();
    public static IList<SupplyChain> SupplyChains {
        get => new List<SupplyChain>(_supplyChains);
        private set => _supplyChains = value;
    }

    private IList<Ingredient> _associatedIngridients = new List<Ingredient>();
    public IList<Ingredient> AssociatedIngridients {
        get => new List<Ingredient>(_associatedIngridients);
        private set => _associatedIngridients = value;
    }

    public string Name { get; private set; }
    public int TransitionTime { get; private set; }

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
        _associatedIngridients.Add(ingredient);
        ingredient.AddSupplyChainInternally(this);
    }

    public void RemoveIngredient(Ingredient ingredient) {
        if(!_associatedIngridients.Remove(ingredient))
            throw new ArgumentException("SupplyChain not found.");
        ingredient.RemoveSupplyChainInternally(this);
    }

    public void AddIngredientInternally(Ingredient ingredient) => _associatedIngridients.Add(ingredient);

    public void RemoveIngredientInternally(Ingredient ingredient) {
        if (!_associatedIngridients.Remove(ingredient))
            throw new ArgumentException("Ingridient not found.");
    }

    public void EditIngredient(Ingredient oldIngredient, Ingredient newIngredient) {
        if(_associatedIngridients.Contains(oldIngredient)) {
            RemoveIngredient(oldIngredient);
        } else {
            throw new ArgumentException("Old ingredient not found.");
        }
        AddIngredient(newIngredient);
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
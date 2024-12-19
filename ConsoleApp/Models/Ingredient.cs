using System.Text.Json;

namespace ConsoleApp.models;

public enum StateAttribute {
    Gas,
    Liquid,
    Solid
}

public class Ingredient {
    private static IList<Ingredient> _ingredients = new List<Ingredient>();
    public static IList<Ingredient> Ingredients {
        get => new List<Ingredient>(_ingredients);
        private set => _ingredients = value;
    }
    public string Name { get; private set; }
    public int PricePerPound { get; private set; }
    public string ChemicalFormula { get; private set; }
    public StateAttribute State { get; private set; }

    private IList<Laboratory> _associatedLaboratories = new List<Laboratory>();
    public IList<Laboratory> AssociatedLaboratories {
        get => new List<Laboratory>(_associatedLaboratories);
        private set => _associatedLaboratories = value;
    }

    public IList<SupplyChain> _associatedSupplyChains = new List<SupplyChain>();
    public IList<SupplyChain> AssociatedSupplyChains {
        get => new List<SupplyChain>(_associatedSupplyChains);
        private set => _associatedSupplyChains = value;
    }

    public Ingredient(string name, int pricePerPound, string chemicalFormula, StateAttribute state) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (pricePerPound < 0)
            throw new ArgumentException("Price per pound cannot be negative.");
        if (string.IsNullOrWhiteSpace(chemicalFormula))
            throw new ArgumentException("Chemical formula cannot be null or whitespace.");

        Name = name;
        PricePerPound = pricePerPound;
        ChemicalFormula = chemicalFormula;
        State = state;
        _ingredients.Add(this);
    }

    public void AddLaboratory(Laboratory laboratory) {
        _associatedLaboratories.Add(laboratory);
        laboratory.AddIngredientInternally(this);
    }

    public void RemoveLaboratory(Laboratory laboratory) {
        if (!_associatedLaboratories.Remove(laboratory))
            throw new ArgumentException("Laboratory not found.");
        laboratory.RemoveIngredientInternally(this);
    }

    public void EditLaboratory(Laboratory oldLaboratory, Laboratory newLaboratory) {
        RemoveLaboratory(oldLaboratory);
        AddLaboratory(newLaboratory);
    }

    public void AddLaboratoryInternally(Laboratory laboratory) => _associatedLaboratories.Add(laboratory);

    public void RemoveLaboratoryInternally(Laboratory laboratory) {
        if (!_associatedLaboratories.Remove(laboratory))
            throw new ArgumentException("Laboratory not found.");
    }

    public void AddSupplyChain(SupplyChain supplyChain) {
        _associatedSupplyChains.Add(supplyChain);
        supplyChain.AddIngredientInternally(this);
    }

    public void RemoveSupplyChain(SupplyChain supplyChain) {
        if (!_associatedSupplyChains.Remove(supplyChain))
            throw new ArgumentException("SupplyChain not found.");
        supplyChain.RemoveIngredientInternally(this);
    }

    public void AddSupplyChainInternally(SupplyChain supplyChain) => _associatedSupplyChains.Add(supplyChain);

    public void RemoveSupplyChainInternally(SupplyChain supplyChain) {
        if (!_associatedSupplyChains.Remove(supplyChain))
            throw new ArgumentException("SupplyChain not found.");
    }

    public void EditSupplyChain(SupplyChain oldSupplyChain, SupplyChain newSupplyChain) {
        if (_associatedSupplyChains.Contains(oldSupplyChain)) {
            RemoveSupplyChain(oldSupplyChain);
        } else {
            throw new ArgumentException("Old supply chain not found.");
        }
        AddSupplyChain(newSupplyChain);
    }

    public static void Serialize() {
        string fileName = "Ingredients.json";
        try {
            string jsonString = JsonSerializer.Serialize(Ingredients, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Ingredients.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Ingredients = JsonSerializer.Deserialize<List<Ingredient>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
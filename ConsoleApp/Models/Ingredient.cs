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
        get => _ingredients.ToList();
        private set => _ingredients = value;
    }

    private IList<Laboratory> _associatedLaboratories = new List<Laboratory>();
    public IList<Laboratory> AssociatedLaboratories {
        get => _associatedLaboratories.ToList();
        private set => _associatedLaboratories = value;
    }

    public SupplyChain? AssociatedSupplyChain { get; private set; }

    private IList<Instruction> _associatedInstructions = new List<Instruction>();
    public IList<Instruction> AssociatedInstructions {
        get => _associatedInstructions.ToList();
        private set => _associatedInstructions = value;
    }

    public string Name { get; private set; }
    public int PricePerPound { get; private set; }
    public string ChemicalFormula { get; private set; }
    public StateAttribute State { get; private set; }

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

    public static void OrderRequired(
        string name, int pricePerPound, string chemicalFormula, StateAttribute state,
        string laboratoryLocation, string supplyChainName
    ) {
        if (string.IsNullOrWhiteSpace(laboratoryLocation))
            throw new ArgumentException("Laboratory location cannot be null or whitespace.");
        else if (Laboratory.Laboratories.FirstOrDefault(l => l.Location == laboratoryLocation) == null)
            throw new ArgumentException("Laboratory not found.");

        if (string.IsNullOrWhiteSpace(supplyChainName))
            throw new ArgumentException("Supply chain name cannot be null or whitespace.");
        else if (SupplyChain.SupplyChains.FirstOrDefault(sc => sc.Name == supplyChainName) == null)
            throw new ArgumentException("Supply chain not found.");

        Laboratory laboratory = Laboratory.Laboratories.First(l => l.Location == laboratoryLocation);
        SupplyChain supplyChain = SupplyChain.SupplyChains.First(sc => sc.Name == supplyChainName);

        Console.WriteLine($"Ordering {name} from {supplyChainName}...");
        Thread.Sleep(supplyChain.TransitionTime * 1000);
        Console.WriteLine("Order complete.");

        Ingredient ingredient = new(name, pricePerPound, chemicalFormula, state);
        ingredient.AddLaboratory(laboratory);
        ingredient.AddSupplyChain(supplyChain);
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

    public void AddLaboratoryInternally(Laboratory laboratory) =>
        _associatedLaboratories.Add(laboratory);

    public void RemoveLaboratoryInternally(Laboratory laboratory) {
        if (!_associatedLaboratories.Remove(laboratory))
            throw new ArgumentException("Laboratory not found.");
    }

    public void AddSupplyChain(SupplyChain supplyChain) {
        AssociatedSupplyChain = supplyChain;
        supplyChain.AddIngredientInternally(this);
    }

    public void RemoveSupplyChain() {
        if (AssociatedSupplyChain == null)
            throw new ArgumentException("No supply chain to remove.");
        AssociatedSupplyChain.RemoveIngredientInternally(this);
        AssociatedSupplyChain = null;
    }

    public void EditSupplyChain(SupplyChain newSupplyChain) {
        RemoveSupplyChain();
        AddSupplyChain(newSupplyChain);
    }

    public void AddSupplyChainInternally(SupplyChain supplyChain) =>
        AssociatedSupplyChain = supplyChain;

    public void RemoveSupplyChainInternally() {
        AssociatedSupplyChain = null;
    }

    public void AddInstruction(Instruction instruction) {
        _associatedInstructions.Add(instruction);
        instruction.AddIngredientInternally(this);
    }

    public void RemoveInstruction(Instruction instruction) {
        if (!_associatedInstructions.Remove(instruction)) {
            throw new ArgumentException("Instruction not found.");
        }
        instruction.RemoveIngredientInternally(this);
    }

    public void EditInstruction(Instruction oldInstruction, Instruction newInstruction) {
        RemoveInstruction(oldInstruction);
        AddInstruction(newInstruction);
    }

    public void AddInstructionInternally(Instruction instruction) =>
        _associatedInstructions.Add(instruction);

    public void RemoveInstructionInternally(Instruction instruction) {
        if (!_associatedInstructions.Remove(instruction))
            throw new ArgumentException("Instruction not found.");
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
using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public class Recipe : ICompositionAssociation<Instruction> {
    private static IList<Recipe> _recipes = new List<Recipe>();
    public static IList<Recipe> Recipes {
        get => new List<Recipe>(_recipes);
        private set => _recipes = value;
    }
    public string Name { get; private set; }
    public int Complexity { get => _associatedInstructions.Count / 10; }

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    private IList<Instruction> _associatedInstructions = new List<Instruction>();
    public IList<Instruction> AssociatedInstructions {
        get => new List<Instruction>(_associatedInstructions);
        private set => _associatedInstructions = value;
    }

    public Recipe(string name) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");

        Name = name;
        _recipes.Add(this);
    }

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddRecipeInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found exception.");
        product.RemoveRecipeInternally(this);
    }

    public void EditProduct(Product oldProduct, Product newProduct) {
        RemoveProduct(oldProduct);
        AddProduct(newProduct);
    }

    public void AddProductInternally(Product product) =>
        _associatedProducts.Add(product);

    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found exception.");
    }

    public void AddCompositionAssociation(Instruction instruction) {
        if (instruction.AssociatedRecipe != null)
            throw new ArgumentException("Instruction is already associated with a recipe.");
        _associatedInstructions.Add(instruction);
        instruction.AddRecipeInternally(this);
    }

    public void RemoveCompositionAssociation(Instruction instruction) {
        if (instruction.AssociatedRecipe == null)
            throw new ArgumentException("Instruction is not associated with a recipe.");
        _associatedInstructions.Remove(instruction);
        instruction.RemoveRecipeInternally();
    }

    public void EditCompositionAssociation(Instruction oldInstruction, Instruction newInstruction) {
        RemoveCompositionAssociation(oldInstruction);
        AddCompositionAssociation(newInstruction);
    }

    public void AddCompositionAssociationInternally(Instruction instruction) {
        if (instruction.AssociatedRecipe != null)
            throw new ArgumentException("Instruction is already associated with a recipe.");
        _associatedInstructions.Add(instruction);
    }

    public void RemoveCompositionAssociationInternally(Instruction instruction) {
        if (instruction.AssociatedRecipe == null)
            throw new ArgumentException("Instruction is not associated with a recipe.");
        _associatedInstructions.Remove(instruction);
    }

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
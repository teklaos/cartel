using System.Text.Json;

namespace ConsoleApp.models;

public class Instruction {
    private static IList<Instruction> _instructions = new List<Instruction>();
    public static IList<Instruction> Instructions {
        get => new List<Instruction>(_instructions);
        private set => _instructions = value;
    }
    public string Action { get; private set; }

    public Recipe? AssociatedRecipe { get; private set; }
    private IList<Ingredient> _associatedIngredients = new List<Ingredient>();
    public IList<Ingredient> AssociatedIngredients {
        get => new List<Ingredient>(_associatedIngredients);
        private set => _associatedIngredients = value;
    }

    public Instruction(string action) {
        Action = action;
        _instructions.Add(this);
    }

    public static IList<string> GetActions() =>
        Instructions.Select(instruction => instruction.Action).ToList();

    public void AddRecipe(Recipe recipe) {
        recipe.AddCompositionAssociationInternally(this);
        AssociatedRecipe = recipe;
    }

    public void RemoveRecipe(Recipe recipe) {
        recipe.RemoveCompositionAssociationInternally(this);
        AssociatedRecipe = null;
    }

    public void EditRecipe(Recipe oldRecipe, Recipe newRecipe) {
        RemoveRecipe(oldRecipe);
        AddRecipe(newRecipe);
    }

    public void AddRecipeInternally(Recipe recipe) {
        AssociatedRecipe = recipe;
    }

    public void RemoveRecipeInternally() {
        AssociatedRecipe = null;
    }

    public void AddIngredient(Ingredient ingredient) {
        _associatedIngredients.Add(ingredient);
        ingredient.AddInstructionInternally(this);
    }

    public void RemoveIngredient(Ingredient ingredient) {
        if (!_associatedIngredients.Remove(ingredient))
            throw new ArgumentException("Ingredient not found.");
        ingredient.RemoveInstructionInternally(this);
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
        string fileName = "Instructions.json";
        try {
            string jsonString = JsonSerializer.Serialize(Instructions, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Instructions.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Instructions = JsonSerializer.Deserialize<List<Instruction>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Clear() {
        _instructions.Clear();
        Serialize();
    }

    ~Instruction() {
        try {
            _instructions?.Remove(this);
        } catch (ArgumentException ex) {
            Console.WriteLine($"Failed to remove instruction: {ex.Message}.");
        }
    }
}
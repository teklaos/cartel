using System.Text.Json;

namespace ConsoleApp.models;

public enum AddLevelAttribute {
    Weak,
    Medium,
    Strong
}

public class Product {
    private static IList<Product> _products = new List<Product>();
    public static IList<Product> Products {
        get => _products.ToList();
        private set => _products = value;
    }

    private IList<Warehouse> _associatedWarehouses = new List<Warehouse>();
    public IList<Warehouse> AssociatedWarehouses {
        get => _associatedWarehouses.ToList();
        private set => _associatedWarehouses = value;
    }

    private IList<Deliverer> _associatedDeliverers = new List<Deliverer>();
    public IList<Deliverer> AssociatedDeliverers {
        get => _associatedDeliverers.ToList();
        private set => _associatedDeliverers = value;
    }

    private Recipe AssignedRecipe { get; set; } = null!;
    private IList<Recipe> _associatedRecipes = new List<Recipe>();
    public IList<Recipe> AssociatedRecipes {
        get => _associatedRecipes.ToList();
        private set => _associatedRecipes = value;
    }

    private Laboratory AssignedLaboratory { get; set; } = null!;
    private IList<Laboratory> _associatedLaboratories = new List<Laboratory>();
    public IList<Laboratory> AssociatedLaboratories {
        get => _associatedLaboratories.ToList();
        private set => _associatedLaboratories = value;
    }

    private Chemist[] AssignedChemists { get; set; } = null!;
    private IList<Chemist> _associatedChemists = new List<Chemist>();
    public IList<Chemist> AssociatedChemists {
        get => _associatedChemists.ToList();
        private set => _associatedChemists = value;
    }

    public string Name { get; private set; }
    public double Weight { get; private set; }
    public int PricePerPound { get; private set; }
    public double PurityPercentage {
        get {
            if (_associatedChemists.Count == 0)
                return 90.0;

            int maxPoundsCooked = _associatedChemists.Max(ch => ch.PoundsCooked);
            double randomDouble = 0.8565;

            if (maxPoundsCooked > 2000)
                return 95 + Math.Round(randomDouble * 5, 2);
            else if (maxPoundsCooked > 1000)
                return 85 + Math.Round(randomDouble * 10, 2);
            else if (maxPoundsCooked > 0)
                return 70 + Math.Round(randomDouble * 15, 2);
            else
                return 50 + Math.Round(randomDouble * 20, 2);
        }
    }
    public AddLevelAttribute AddictivenessLevel { get; private set; }

    public Product(string name, double weight, int pricePerPound, AddLevelAttribute addictivenessLevel) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (weight < 0)
            throw new ArgumentException("Weight cannot be negative.");
        if (pricePerPound < 0)
            throw new ArgumentException("Price per pound cannot be negative.");

        Name = name;
        Weight = weight;
        PricePerPound = pricePerPound;
        AddictivenessLevel = addictivenessLevel;
        _products.Add(this);
    }

    public Product(
        string name, double weight, int pricePerPound, AddLevelAttribute addictivenessLevel,
        Chemist? chemist1, Chemist? chemist2
    ) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (weight < 0)
            throw new ArgumentException("Weight cannot be negative.");
        if (pricePerPound < 0)
            throw new ArgumentException("Price per pound cannot be negative.");

        Name = name;
        Weight = weight;
        PricePerPound = pricePerPound;
        AddictivenessLevel = addictivenessLevel;
        _products.Add(this);

        if (chemist1 != null && chemist2 != null)
            AddChemists(chemist1, chemist2);
        else if (chemist1 != null)
            AddChemists(chemist1, new Chemist("Dummy", 10, ["Listen to your boss."], 200, "Chemist", 0));
        else if (chemist2 != null)
            AddChemists(new Chemist("Dummy", 10, ["Listen to your boss."], 200, "Chemist", 0), chemist2);
        else
            AddChemists(
                new Chemist("Dummy", 10, ["Listen to your boss."], 200, "Chemist", 0),
                new Chemist("Dummy", 10, ["Listen to your boss."], 200, "Chemist", 0)
            );
    }

    public static Product StartBatch(
        string name, double weight, int pricePerPound, AddLevelAttribute addictivenessLevel,
        string recipeName, string laboratoryLocation, params string[] chemistNames
    ) {
        if (string.IsNullOrWhiteSpace(recipeName))
            throw new ArgumentException("Recipe name cannot be null or whitespace.");
        else if (Recipe.Recipes.FirstOrDefault(r => r.Name == recipeName) == null)
            throw new ArgumentException("Recipe not found.");

        if (string.IsNullOrWhiteSpace(laboratoryLocation))
            throw new ArgumentException("Laboratory location cannot be null or whitespace.");
        else if (Laboratory.Laboratories.FirstOrDefault(l => l.Location == laboratoryLocation) == null)
            throw new ArgumentException("Laboratory not found.");

        if (chemistNames.Length < 2)
            throw new ArgumentException("Not enough chemists.");

        Product product = new(name, weight, pricePerPound, addictivenessLevel) {
            AssignedRecipe = Recipe.Recipes.First(r => r.Name == recipeName),
            AssignedLaboratory = Laboratory.Laboratories.First(l => l.Location == laboratoryLocation),
            AssignedChemists = chemistNames.Select(ch => Chemist.Chemists.First(c => c.Name == ch)).ToArray()
        };

        Console.WriteLine("Cooking batch...");
        Thread.Sleep(10000);
        Console.WriteLine("Batch cooked.");

        return product;
    }

    public void CompleteBatch() {
        AddRecipe(AssignedRecipe);
        AddLaboratory(AssignedLaboratory);
        AddChemists(AssignedChemists);
    }

    public static IList<Dictionary<string, string>> GetViewData() {
        return (List<Dictionary<string, string>>)Products.Select(product => new Dictionary<string, string> {
            { "Name", product.Name },
            { "Weight", product.Weight.ToString() },
            { "Price Per Pound", product.PricePerPound.ToString() },
            { "Purity Percentage", product.PurityPercentage.ToString() }
        });
    }

    public void AddWarehouse(Warehouse warehouse) {
        _associatedWarehouses.Add(warehouse);
        warehouse.AddProductInternally(this);
    }

    public void RemoveWarehouse(Warehouse warehouse) {
        if (!_associatedWarehouses.Remove(warehouse))
            throw new ArgumentException("Warehouse not found.");
        warehouse.RemoveProductInternally(this);
    }

    public void EditWarehouse(Warehouse oldWarehouse, Warehouse newWarehouse) {
        RemoveWarehouse(oldWarehouse);
        AddWarehouse(newWarehouse);
    }

    public void AddWarehouseInternally(Warehouse warehouse) =>
        _associatedWarehouses.Add(warehouse);

    public void RemoveWarehouseInternally(Warehouse warehouse) {
        if (!_associatedWarehouses.Remove(warehouse))
            throw new ArgumentException("Warehouse not found.");
    }

    public void AddDeliverer(Deliverer deliverer) {
        _associatedDeliverers.Add(deliverer);
        deliverer.AddProductInternally(this);
    }

    public void RemoveDeliverer(Deliverer deliverer) {
        if (!_associatedDeliverers.Remove(deliverer))
            throw new ArgumentException("Deliverer not found.");
        deliverer.RemoveProductInternally(this);
    }

    public void EditDeliverer(Deliverer oldDeliverer, Deliverer newDeliverer) {
        RemoveDeliverer(oldDeliverer);
        AddDeliverer(newDeliverer);
    }

    public void AddDelivererInternally(Deliverer deliverer) =>
        _associatedDeliverers.Add(deliverer);

    public void RemoveDelivererInternally(Deliverer deliverer) {
        if (!_associatedDeliverers.Remove(deliverer))
            throw new ArgumentException("Deliverer not found.");
    }

    public void AddRecipe(Recipe recipe) {
        _associatedRecipes.Add(recipe);
        recipe.AddProductInternally(this);
    }

    public void RemoveRecipe(Recipe recipe) {
        if (!_associatedRecipes.Remove(recipe))
            throw new ArgumentException("Recipe not found.");
        recipe.RemoveProductInternally(this);
    }

    public void EditRecipe(Recipe oldRecipe, Recipe newRecipe) {
        RemoveRecipe(oldRecipe);
        AddRecipe(newRecipe);
    }

    public void AddRecipeInternally(Recipe recipe) =>
        _associatedRecipes.Add(recipe);

    public void RemoveRecipeInternally(Recipe recipe) {
        if (!_associatedRecipes.Remove(recipe))
            throw new ArgumentException("Recipe not found.");
    }

    public void AddLaboratory(Laboratory laboratory) {
        _associatedLaboratories.Add(laboratory);
        laboratory.AddProductInternally(this);
    }

    public void RemoveLaboratory(Laboratory laboratory) {
        if (!_associatedLaboratories.Remove(laboratory))
            throw new ArgumentException("Laboratory not found.");
        laboratory.RemoveProductInternally(this);
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

    public void AddChemists(params Chemist[] chemists) {
        if (chemists.Distinct().Count() != chemists.Length)
            throw new ArgumentException("Chemists should be unique.");
        if (_associatedChemists.Count + chemists.Length < 2)
            throw new ArgumentException("Not enough chemists.");
        foreach (Chemist chemist in chemists) {
            _associatedChemists.Add(chemist);
            chemist.AddProductInternally(this);
        }
    }

    public void RemoveChemist(Chemist chemist) {
        if (_associatedChemists.Count - 1 < 2)
            throw new ArgumentException("Chemist cannot be deleted.");
        if (!_associatedChemists.Remove(chemist))
            throw new ArgumentException("Chemist not found.");
        chemist.RemoveProductInternally(this);
    }

    public void EditChemist(Chemist oldChemist, Chemist newChemist) {
        RemoveChemist(oldChemist);
        AddChemists(newChemist);
    }

    public void AddChemistInternally(Chemist chemist) =>
        _associatedChemists.Add(chemist);

    public void RemoveChemistInternally(Chemist chemist) {
        if (!_associatedChemists.Remove(chemist))
            throw new ArgumentException("Chemist not found.");
    }

    public static void Serialize() {
        string fileName = "Products.json";
        try {
            string jsonString = JsonSerializer.Serialize(Products, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Deserialize() {
        string fileName = "Products.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Products = JsonSerializer.Deserialize<List<Product>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public static void Clear() {
        _products.Clear();
        Serialize();
    }
}
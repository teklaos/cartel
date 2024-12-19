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
        get => new List<Product>(_products);
        private set => _products = value;
    }
    public string Name { get; private set; }
    public int PricePerPound { get; private set; }
    private readonly int _poundsCooked = 2000;
    public double PurityPercentage {
        get {
            double randomDouble = 0.8565;
            if (_poundsCooked > 2000)
                return 95 + Math.Round(randomDouble * 5, 2);
            else if (_poundsCooked > 1000)
                return 85 + Math.Round(randomDouble * 10, 2);
            else if (_poundsCooked > 0)
                return 70 + Math.Round(randomDouble * 15, 2);
            else
                return 50 + Math.Round(randomDouble * 20, 2);
        }
    }
    public AddLevelAttribute AddictivenessLevel { get; private set; }

    private IList<Deliverer> _associatedDeliverers = new List<Deliverer>();
    public IList<Deliverer> AssociatedDeliverers {
        get => new List<Deliverer>(_associatedDeliverers);
        private set => _associatedDeliverers = value;
    }

    private IList<Warehouse> _associatedWarehouses = new List<Warehouse>();
    public IList<Warehouse> AssociatedWarehouses {
        get => new List<Warehouse>(_associatedWarehouses);
        private set => _associatedWarehouses = value;
    }

    private IList<Chemist> _associatedChemists = new List<Chemist>();
    public IList<Chemist> AssociatedChemists {
        get => new List<Chemist>(_associatedChemists);
        private set => _associatedChemists = value;
    }

    private IList<Recipe> _associatedRecipes = new List<Recipe>();

    public IList<Recipe> AssociatedRecipes {
        get => new List<Recipe>(_associatedRecipes);
        private set => _associatedRecipes = value;
    }

    public Product(string name, int pricePerPound, AddLevelAttribute addictivenessLevel) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.");
        if (pricePerPound < 0)
            throw new ArgumentException("Price per pound cannot be negative.");

        Name = name;
        PricePerPound = pricePerPound;
        AddictivenessLevel = addictivenessLevel;
        _products.Add(this);
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

    public void AddWarehouseInternally(Warehouse warehouse) => _associatedWarehouses.Add(warehouse);

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

    public void AddDelivererInternally(Deliverer deliverer) => _associatedDeliverers.Add(deliverer);

    public void RemoveDelivererInternally(Deliverer deliverer) {
        if (!_associatedDeliverers.Remove(deliverer))
            throw new ArgumentException("Deliverer not found.");
    }

    public void AddChemist(Chemist chemist) {
        _associatedChemists.Add(chemist);
        chemist.AddProductInternally(this);
    }

    public void RemoveChemist(Chemist chemist) {
        if(!_associatedChemists.Remove(chemist))
            throw new ArgumentException("Chemist not found.");
        chemist.RemoveProductInternally(this);
    }

    public void AddChemistInternally(Chemist chemist) => _associatedChemists.Add(chemist);
    
    public void RemoveChemistInternally(Chemist chemist) {
        if(!_associatedChemists.Remove(chemist))
            throw new ArgumentException("Chemist not found.");
    }

    public void AddRecipe(Recipe recipe) {
        _associatedRecipes.Add(recipe);
        recipe.AddProductInternally(this);
    }

    public void RemoveRecipe(Recipe recipe) {
        if(!_associatedRecipes.Remove(recipe))
            throw new ArgumentException("Recipe not found.");
        recipe.RemoveProductInternally(this);
    }

    public void AddRecipeInternally(Recipe recipe) => _associatedRecipes.Add(recipe);
    
    public void RemoveRecipeInternally(Recipe recipe) {
        if(!_associatedRecipes.Remove(recipe))
            throw new ArgumentException("Recipe not found.");
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
}
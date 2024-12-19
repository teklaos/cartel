using System.Collections;
using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public class Chemist : CartelMember, IReflexiveConnection<Chemist> {
    private static IList<Chemist> _chemists = new List<Chemist>();
    private IList<Product> _associatedProducts = new List<Product>();
    private IList<Chemist> _supervisedChemists = new List<Chemist>();
    private IList<Chemist> _supervisors = new List<Chemist>();
    
    public IList<Chemist> Supervisors {
        get => new List<Chemist>(_supervisors);
        private set => _supervisors = value;
    }
    public IList<Chemist> SupervisedChemists {
        get => new List<Chemist>(_supervisedChemists);
        private set => _supervisedChemists = value;
    }
    public static IList<Chemist> Chemists {
        get => new List<Chemist>(_chemists);
        private set => _chemists = value;
    }

    public IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    public int PoundsCooked { get; private set; }

    public Chemist(string name, int trustLevel, IList<string> rulesToFollow, int poundsCooked) :
    base(name, trustLevel, rulesToFollow) {
        if (poundsCooked < 0)
            throw new ArgumentException("Cooked pounds cannot be negative.");

        PoundsCooked = poundsCooked;
        _chemists.Add(this);
    }


    public void CreateSelfConnection(Chemist entity)
    {
        _supervisedChemists.Add(entity);
        entity.Supervisors.Add(this);
    }

    public void DestroySelfConnection(Chemist entity)
    {
        _supervisedChemists.Remove(entity);
        entity.Supervisors.Remove(this);
    }

    public void EditSelfConnection(Chemist entity)
    {
        DestroySelfConnection(entity);
        CreateSelfConnection(entity);
    }

    public void AddProduct(Product product) {
        _associatedProducts.Add(product);
        product.AddChemistInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new Exception("Product not found exception.");
        product.RemoveChemistInternally(this);
    }

    public void AddProductInternally(Product product) => _associatedProducts.Add(product);
    
    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new Exception("Product not found exception.");
    }
    
    public new static void Serialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = JsonSerializer.Serialize(Chemists, AppConfig.JsonOptions);
            File.WriteAllText(fileName, jsonString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public new static void Deserialize() {
        string fileName = "Chemists.json";
        try {
            string jsonString = File.ReadAllText(fileName);
            Chemists = JsonSerializer.Deserialize<List<Chemist>>(jsonString, AppConfig.JsonOptions) ?? [];
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
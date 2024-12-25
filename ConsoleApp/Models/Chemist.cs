using System.Text.Json;
using ConsoleApp.Abstractions.Interfaces;

namespace ConsoleApp.models;

public class Chemist : CartelMember, IReflexiveAssociation<Chemist> {
    private static IList<Chemist> _chemists = new List<Chemist>();
    public static IList<Chemist> Chemists {
        get => new List<Chemist>(_chemists);
        private set => _chemists = value;
    }
    public int PoundsCooked { get; private set; }

    public Chemist? Supervisor { get; private set; }

    private IList<Chemist> _supervisedChemists = new List<Chemist>();
    public IList<Chemist> SupervisedChemists {
        get => new List<Chemist>(_supervisedChemists);
        private set => _supervisedChemists = value;
    }

    private IList<Product> _associatedProducts = new List<Product>();
    public IList<Product> AssociatedProducts {
        get => new List<Product>(_associatedProducts);
        private set => _associatedProducts = value;
    }

    public Chemist(string name, int trustLevel, IList<string> rulesToFollow, int poundsCooked) :
    base(name, trustLevel, rulesToFollow) {
        if (poundsCooked < 0)
            throw new ArgumentException("Cooked pounds cannot be negative.");

        PoundsCooked = poundsCooked;
        _chemists.Add(this);
    }

    public void AddSelfAssociation(Chemist chemist) {
        if (this == chemist)
            throw new ArgumentException("Chemist cannot supervise themselves.");
        if (chemist.Supervisor != null)
            throw new ArgumentException("Chemist has a supervisor.");
        _supervisedChemists.Add(chemist);
        chemist.Supervisor = this;
    }

    public void RemoveSelfAssociation(Chemist chemist) {
        if (!_supervisedChemists.Remove(chemist))
            return; // throw new Exception(); <--- breaks unit tests
        chemist.Supervisor = null;
    }

    public void EditSelfAssociation(Chemist oldChemist, Chemist newChemist) {
        RemoveSelfAssociation(oldChemist);
        AddSelfAssociation(newChemist);
    }

    public void AddProduct(Product product) {
        if (product.AssociatedChemists.Count < 1)
            throw new ArgumentException("Association does not have enough chemists.");
        _associatedProducts.Add(product);
        product.AddChemistInternally(this);
    }

    public void RemoveProduct(Product product) {
        if (product.AssociatedChemists.Count - 1 < 2)
            throw new ArgumentException("Association cannot be removed.");
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
        product.RemoveChemistInternally(this);
    }

    public void EditProduct(Product oldProduct, Product newProduct) {
        RemoveProduct(oldProduct);
        AddProduct(newProduct);
    }

    public void AddProductInternally(Product product) => _associatedProducts.Add(product);

    public void RemoveProductInternally(Product product) {
        if (!_associatedProducts.Remove(product))
            throw new ArgumentException("Product not found.");
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

    ~Chemist() {
        RemoveSelfAssociation(this);
    }

}
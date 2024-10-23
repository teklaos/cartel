namespace ConsoleApp;

public enum StateAttribute {
    Gas,
    Liquid,
    Solid
}

public class Ingredient {
    private static IEnumerable<Ingredient> _ingredients = new List<Ingredient>();
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string ChemicalFormula { get; set; } = null!;
    public StateAttribute State { get; set; }

    public Ingredient(string name, int price, string chemicalFormula, StateAttribute state) {
        this.Name = name;
        this.Price = price;
        this.ChemicalFormula = chemicalFormula;
        this.State = state;
        _ingredients = _ingredients.Append(this);
    }
}
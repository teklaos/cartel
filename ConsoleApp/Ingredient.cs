namespace ConsoleApp;

public enum StateAttribute {
    Gas,
    Liquid,
    Solid
}

public class Ingredient {
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public string ChemicalFormula { get; set; } = null!;
    public StateAttribute State { get; set; }
}
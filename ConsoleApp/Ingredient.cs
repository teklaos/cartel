namespace ConsoleApp;

public enum PhysicalState {
    Gas,
    Liquid,
    Solid
}

public class Ingredient {
    private string Name { get; set; } = null!;
    private int Price { get; set; }
    private string ChemicalFormula { get; set; } = null!;
    private PhysicalState State { get; set; }
}
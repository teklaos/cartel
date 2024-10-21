namespace ConsoleApp;

public enum ActionAttribute {
    Add,
    Stir,
    Combine
}

public class Instruction {
    public ActionAttribute Action { get; set; }
}
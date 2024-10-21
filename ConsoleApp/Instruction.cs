namespace ConsoleApp;

public enum InstructAction {
    Add,
    Stir,
    Combine
}

public class Instruction {
    public InstructAction Action { get; set; }
}
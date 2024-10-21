namespace ConsoleApp;

public enum InstructAction {
    Add,
    Stir,
    Combine
}

public class Instruction {
    private InstructAction Action { get; set; }
}
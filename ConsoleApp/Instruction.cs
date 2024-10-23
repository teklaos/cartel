namespace ConsoleApp;

public enum ActionAttribute {
    Add,
    Stir,
    Combine
}

public class Instruction {
    public static IEnumerable<Instruction> _instructions { get; private set; } = new List<Instruction>();
    public ActionAttribute Action { get; set; }

    public Instruction(ActionAttribute action) {
        this.Action = action;
        _instructions = _instructions.Append(this);
    }
}
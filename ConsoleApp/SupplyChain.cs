namespace ConsoleApp;

public class SupplyChain {
    public string Name { get; set; } = null!;
    public int TransitionTime { get; set; } // In hours

    public SupplyChain(string name, int transitionTime) {
        this.Name = name;
        this.TransitionTime = transitionTime;
    }
}
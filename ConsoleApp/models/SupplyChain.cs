namespace ConsoleApp.models;

public class SupplyChain {
    public static IEnumerable<SupplyChain> _supplyChains { get; private set; } = new List<SupplyChain>();
    public string Name { get; set; } = null!;
    public int TransitionTime { get; set; } // In hours

    public SupplyChain(string name, int transitionTime) {
        this.Name = name;
        this.TransitionTime = transitionTime;
        _supplyChains = _supplyChains.Append(this);
    }
}
namespace ConsoleApp.models;

public class Deliverer : CartelMember {
    public static IEnumerable<Deliverer> _deliverers { get; private set; } = new List<Deliverer>();
    
    public Deliverer(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        _deliverers = _deliverers.Append(this);
    }
}
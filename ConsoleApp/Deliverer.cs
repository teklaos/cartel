namespace ConsoleApp;

public class Deliverer : CartelMember {
    private static IEnumerable<Deliverer> _deliverers = new List<Deliverer>();
    public Deliverer(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        _deliverers = _deliverers.Append(this);
    }
}
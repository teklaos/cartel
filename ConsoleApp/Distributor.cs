namespace ConsoleApp;

public class Distributor : CartelMember {
    private static IEnumerable<Distributor> _distributors = new List<Distributor>();
    public Distributor(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        _distributors = _distributors.Append(this);
    }
}
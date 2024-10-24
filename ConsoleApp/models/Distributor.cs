namespace ConsoleApp.models;

public class Distributor : CartelMember {
    public static IEnumerable<Distributor> _distributors { get; private set; } = new List<Distributor>();
    
    public Distributor(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        _distributors = _distributors.Append(this);
    }
}
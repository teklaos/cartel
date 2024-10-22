namespace ConsoleApp;

public class Deliverer : CartelMember {
    public Deliverer(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {}
}
namespace ConsoleApp;

public class Distributor : CartelMember {
    public Distributor(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {}
}
namespace ConsoleApp;

public class Citizen : CartelMember {
    public Citizen(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {}
}
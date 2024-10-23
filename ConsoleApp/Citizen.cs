namespace ConsoleApp;

public class Citizen : CartelMember {
    private static IEnumerable<Citizen> _citizens = new List<Citizen>();
    public Citizen(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        _citizens = _citizens.Append(this);
    }
}
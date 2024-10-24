namespace ConsoleApp.models;

public class Citizen : CartelMember {
    public static IEnumerable<Citizen> _citizens { get; private set; } = new List<Citizen>();
    
    public Citizen(string name, int trustLevel, IEnumerable<string> rulesToFollow):
    base(name, trustLevel, rulesToFollow) {
        _citizens = _citizens.Append(this);
    }
}
namespace ConsoleApp.models;

public abstract class CartelMember {
    public static IEnumerable<CartelMember> _cartelMembers { get; private set; } = new List<CartelMember>();
    public string Name { get; set; } = null!;
    public int TrustLevel { get; set; }
    public IEnumerable<string> RulesToFollow { get; set; } = null!;

    public CartelMember(string name, int trustLevel, IEnumerable<string> rulesToFollow) {
        this.Name = name;
        this.TrustLevel = trustLevel;
        this.RulesToFollow = rulesToFollow;
        _cartelMembers = _cartelMembers.Append(this);
    }
}
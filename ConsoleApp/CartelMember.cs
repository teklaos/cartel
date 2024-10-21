namespace ConsoleApp;

public abstract class CartelMember {
    public abstract string Name { get; }
    public abstract int TrustLevel { get; }
    public abstract IEnumerable<string> RulesToFollow { get; }
}
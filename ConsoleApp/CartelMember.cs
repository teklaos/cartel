namespace ConsoleApp;

public abstract class CartelMember {
    public abstract string Name { get; }
    public abstract int TrustLevel { get; }
    public abstract ICollection<string> RulesToFollow { get; }
}
namespace ConsoleApp;

public class Citizen : CartelMember {
    public override string Name => throw new NotImplementedException();
    public override int TrustLevel => throw new NotImplementedException();
    public override IEnumerable<string> RulesToFollow => throw new NotImplementedException();
}
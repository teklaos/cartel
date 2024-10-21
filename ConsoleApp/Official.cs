namespace ConsoleApp;

public class Official : CartelMember {
    public override string Name => throw new NotImplementedException();
    public override int TrustLevel => throw new NotImplementedException();
    public override ICollection<string> RulesToFollow => throw new NotImplementedException();
    private int Rank { get; set; }
}
namespace ConsoleApp;

public class Chemist : CartelMember {
    public override string Name => throw new NotImplementedException();
    public override int TrustLevel => throw new NotImplementedException();
    public override ICollection<string> RulesToFollow => throw new NotImplementedException();
    private int TimesCooked { get; set; }
}
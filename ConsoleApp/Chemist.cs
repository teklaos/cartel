namespace ConsoleApp;

public class Chemist : CartelMember {
    private static IEnumerable<Chemist> _chemists = new List<Chemist>();
    public int TimesCooked { get; set; }

    public Chemist(string name, int trustLevel, IEnumerable<string> rulesToFollow, int timesCooked):
    base(name, trustLevel, rulesToFollow) {
        this.TimesCooked = timesCooked;
        _chemists = _chemists.Append(this);
    }
}
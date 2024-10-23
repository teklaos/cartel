namespace ConsoleApp.models;

public class Chemist : CartelMember {
    public static IEnumerable<Chemist> _chemists { get; private set; } = new List<Chemist>();
    public int TimesCooked { get; set; }

    public Chemist(string name, int trustLevel, IEnumerable<string> rulesToFollow, int timesCooked):
    base(name, trustLevel, rulesToFollow) {
        this.TimesCooked = timesCooked;
        _chemists = _chemists.Append(this);
    }
}
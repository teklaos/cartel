namespace ConsoleApp;

public class Chemist : CartelMember {
    public int TimesCooked { get; set; }

    public Chemist(string name, int trustLevel, IEnumerable<string> rulesToFollow, int timesCooked):
    base(name, trustLevel, rulesToFollow) {
        this.TimesCooked = timesCooked;
    }
}
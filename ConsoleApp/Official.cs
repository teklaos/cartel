namespace ConsoleApp;

public class Official : CartelMember {
    private static IEnumerable<Official> _officials = new List<Official>();
    public int Rank { get; set; }

    public Official(string name, int trustLevel, IEnumerable<string> rulesToFollow, int rank):
    base(name, trustLevel, rulesToFollow) {
        this.Rank = rank;
        _officials = _officials.Append(this);
    }
}
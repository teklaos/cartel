namespace ConsoleApp;

public class Official : CartelMember {
    public static IEnumerable<Official> _officials { get; private set; } = new List<Official>();
    public int Rank { get; set; }

    public Official(string name, int trustLevel, IEnumerable<string> rulesToFollow, int rank):
    base(name, trustLevel, rulesToFollow) {
        this.Rank = rank;
        _officials = _officials.Append(this);
    }
}
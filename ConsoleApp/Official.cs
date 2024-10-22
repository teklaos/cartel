namespace ConsoleApp;

public class Official : CartelMember {
    public int Rank { get; set; }

    public Official(string name, int trustLevel, IEnumerable<string> rulesToFollow, int rank):
    base(name, trustLevel, rulesToFollow) {
        this.Rank = rank;
    }
}
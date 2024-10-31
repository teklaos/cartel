namespace ConsoleApp.models;

public class Official : CartelMember {
    public static IEnumerable<Official> _officials { get; private set; } = new List<Official>();
    public int Rank { get; private set; }

    public Official(string name, int trustLevel, IEnumerable<string> rulesToFollow, int rank):
    base(name, trustLevel, rulesToFollow) {
        Rank = rank;
        AddOfficial();
    }

    private void AddOfficial() {
        try {
            ArgumentOutOfRangeException.ThrowIfNegative(Rank, "Rank");
            ArgumentNullException.ThrowIfNull(this);
            _officials = _officials.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
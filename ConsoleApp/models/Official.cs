namespace ConsoleApp.models;

public class Official : CartelMember {
    public static IEnumerable<Official> _officials { get; private set; } = new List<Official>();
    public string Position { get; private set; }
    public string Department { get; private set; }

    public Official(string name, int trustLevel, IEnumerable<string> rulesToFollow, string position, string department):
    base(name, trustLevel, rulesToFollow) {
        Position = position;
        Department = department;
        AddOfficial();
    }

    private void AddOfficial() {
        try {
            ArgumentException.ThrowIfNullOrWhiteSpace(Position, "Position");
            ArgumentException.ThrowIfNullOrWhiteSpace(Department, "Department");
            ArgumentNullException.ThrowIfNull(this);
            _officials = _officials.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
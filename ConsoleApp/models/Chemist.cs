namespace ConsoleApp.models;

public class Chemist : CartelMember {
    public static IEnumerable<Chemist> _chemists { get; private set; } = new List<Chemist>();
    public int TimesCooked { get; private set; }

    public Chemist(string name, int trustLevel, IEnumerable<string> rulesToFollow, int timesCooked):
    base(name, trustLevel, rulesToFollow) {
        TimesCooked = timesCooked;
        AddChemist();
    }

    private void AddChemist() {
        try {
            ArgumentOutOfRangeException.ThrowIfNegative(TimesCooked, "Times cooked");
            ArgumentNullException.ThrowIfNull(this);
            _chemists = _chemists.Append(this);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}
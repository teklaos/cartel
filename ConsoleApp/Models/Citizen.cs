namespace ConsoleApp.models;

public class Citizen : CartelMember {
    public Citizen(string name, int trustLevel, IList<string> rulesToFollow, string occupation, int securityLevel) :
    base(name, trustLevel, rulesToFollow) {
        if (string.IsNullOrWhiteSpace(occupation))
            throw new ArgumentException("Occupation cannot be null or whitespace.");
        if (securityLevel < 0)
            throw new ArgumentException("Security level cannot be negative.");

        Occupation = occupation;
        SecurityLevel = securityLevel;
        _citizens.Add(this);
    }
}
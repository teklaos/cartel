namespace ConsoleApp.models;

public class Official : CartelMember {
    public Official(string name, int trustLevel, IList<string> rulesToFollow, string position, string department) :
    base(name, trustLevel, rulesToFollow) {
        if (string.IsNullOrWhiteSpace(position))
            throw new ArgumentException("Position cannot be null or whitespace.");
        if (string.IsNullOrWhiteSpace(department))
            throw new ArgumentException("Department cannot be null or whitespace.");

        Position = position;
        Department = department;
        _officials.Add(this);
    }
}
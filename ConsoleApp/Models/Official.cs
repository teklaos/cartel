namespace ConsoleApp.models;

public class Official : CartelMember {
    public Official(string name, int trustLevel, IList<string> rulesToFollow, string position, string department) :
    base(name, trustLevel, rulesToFollow, position, department) { }
}
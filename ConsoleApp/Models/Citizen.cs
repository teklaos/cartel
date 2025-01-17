namespace ConsoleApp.models;

public class Citizen : CartelMember {
    public Citizen(string name, int trustLevel, IList<string> rulesToFollow, string occupation, int securityLevel) :
    base(name, trustLevel, rulesToFollow, occupation, securityLevel) { }
}
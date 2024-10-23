namespace ConsoleApp;

public class Recipe {
    public static IEnumerable<Recipe> _recipes { get; private set; } = new List<Recipe>();
    public int Complexity { get; set; }

    public Recipe(int complexity) {
        this.Complexity = complexity;
        _recipes.Append(this);
    }
}
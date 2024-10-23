namespace ConsoleApp;

public class Recipe {
    private static IEnumerable<Recipe> recipes = new List<Recipe>();
    public int Complexity { get; set; }

    public Recipe(int complexity) {
        this.Complexity = complexity;
        recipes.Append(this);
    }
}
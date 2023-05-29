using RecipePart2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();

        Console.WriteLine("WELCOME TO THE RECIPE APP!");

        Console.BackgroundColor = ConsoleColor.Black; // Reset the background color to default (black)
        Console.ForegroundColor = ConsoleColor.White; // Set the foreground color to white

        Console.WriteLine("Press Enter to procced");

        Console.ReadLine();

        Dictionary<String, Recipe> dictionaryRecipe = new Dictionary<string, Recipe>();
        Menu menu = new Menu(dictionaryRecipe);
        menu.appMenu();
    }
}

class recipeLogger
{
    private Dictionary<String, Recipe> dictionaryRecipe;
    public recipeLogger(Dictionary<string, Recipe> dictionaryRecipe)
    {
        this.dictionaryRecipe = dictionaryRecipe;
    }

    public void logDetails()
    {
        Console.WriteLine("Enter the number of Recipes:");
        int recipeNum;
        if (int.TryParse(Console.ReadLine(), out recipeNum))
        {
            for (int i = 0; i < recipeNum; i++)
            {
                Console.Write("Enter Recipe Name:");
                String recipeName = Console.ReadLine();
                Recipe recipe = new Recipe();
                recipe.EnterData();
                dictionaryRecipe.Add(recipeName, recipe);
            }
            String ans;
            do
            {
                Console.WriteLine("Display Ingredients and steps?(Y/N)");
                ans = Console.ReadLine();
                switch (ans)
                {
                    case "Y":
                        foreach (var recipeEntry in dictionaryRecipe)
                        {
                            Console.WriteLine($"Recipe Name:{recipeEntry.Key}");
                            recipeEntry.Value.RecipeDisplay();
                        }
                        break;
                    case "N":
                        Menu menu = new Menu(dictionaryRecipe);
                        menu.appMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }

            } while (ans != "N");
        }
        else
        {
            Console.WriteLine("Please enter a number");
        }
    }
    public void recipeList()
    {
        foreach (var recipeEntry in dictionaryRecipe)
        {
            Console.WriteLine($"Recipe Name:{recipeEntry.Key}");
        }
    }
    public void recipeFinder()
    {
        Console.Write("Please enter the name of the Recipe:");
        string recipeName = Console.ReadLine();
        if (dictionaryRecipe.ContainsKey(recipeName))
        {
            Console.WriteLine($"Recipe Name:{recipeName}");
            dictionaryRecipe[recipeName].RecipeDisplay();
        }
        else
        {
            Console.WriteLine("Recipe does not exist");
        }
    }
}

class Menu
{
    private Dictionary<String, Recipe> dictionaryRecipe;
    private recipeLogger repL;
    public Menu(Dictionary<string, Recipe> dictionaryRecipe)
    {
        this.dictionaryRecipe = dictionaryRecipe;
        repL = new recipeLogger(dictionaryRecipe);
    }
    public void appMenu()
    {
        while (true)
        {
            
            Console.WriteLine("RECIPE APP");
            Console.WriteLine("1) Create Recipe");
            Console.WriteLine("2) Search for Recipe");
            Console.WriteLine("3) Display All Recipes");
            Console.WriteLine("4) Exit Application");

            Console.WriteLine("Please Select an Option:");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    repL.logDetails();
                    break;
                case "2":
                    repL.recipeFinder();
                    break;
                case "3":
                    repL.recipeList();
                    break; ;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
        }
    }
}
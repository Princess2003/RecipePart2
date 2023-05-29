using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePart2
{
    internal class Ingredient
    {
        private Dictionary<String, Recipe> dictionaryRecipe;
        public Ingredient(Dictionary<string, Recipe> dictionaryRecipe)
        {
            this.dictionaryRecipe = dictionaryRecipe;
            Recipe recipe = new Recipe();
            while (true)
            {
                
                Console.WriteLine("Enter 1 to enter recipe details");
                Console.WriteLine("Enter 2 to Display Recipe");
                Console.WriteLine("Enter 3 to Scale Recipe");
                Console.WriteLine("Enter 4 to Reset Qauntities");
                Console.WriteLine("Enter 5 to Clear Recipes");
                Console.WriteLine("Enter 6 to go back to main menu");
                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        recipe.EnterData();
                        break;
                    case "2":
                        recipe.RecipeDisplay();
                        break;
                    case "3":
                        Console.WriteLine("Enter a scale of 0.5,2 or 3");
                        double scale1 = Convert.ToDouble(Console.ReadLine());
                        recipe.RecipeScale(scale1);
                        break;
                    case "4":
                        recipe.ResetRecipe();
                        break;
                    case "5":
                        recipe.ClearRecipe();
                        break;
                    case "6":
                        Menu appMenu = new Menu(dictionaryRecipe);
                        appMenu.appMenu();
                        break;
                    default:
                        Console.WriteLine("Wrong value.Please try again");
                        break;
                }
            }
        }
    }

}


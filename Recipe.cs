using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePart2
{
    internal class Recipe
    {
        private String[] ingredients;
        private double[] amount;
        private String[] units;
        private String[] steps;
        private double[] calories;
        private string[] foodGroup;

        public Recipe()
        {
            ingredients = new String[0];
            amount = new double[0];
            units = new String[0];
            steps = new String[0];
            calories = new double[0];
            foodGroup = new String[0];
        }
        public void EnterData()
        {
            Console.WriteLine("Enter number of Ingredients:");
            int ingNum = Convert.ToInt32(Console.ReadLine());

            ingredients = new String[ingNum];
            amount = new double[ingNum];
            units = new String[ingNum];
            calories = new double[ingNum];
            foodGroup = new string[ingNum];

            for (int i = 0; i < ingNum; i++)
            {
                Console.WriteLine($"Enter ingredient details#{i + 1}:");
                Console.Write("Name:");
                ingredients[i] = Console.ReadLine();
                do
                {
                    Console.Write("Quantity:");
                } while (!double.TryParse(Console.ReadLine(), out amount[i]));
                Console.Write("Units of measurement:");
                units[i] = Console.ReadLine();
                do
                {
                    Console.Write("Number of calories:");
                } while (!double.TryParse(Console.ReadLine(), out calories[i]));

                Console.Write("Enter Food Group:");
                foodGroup[i] = Console.ReadLine();
            }
            //Delegation
            double calExceed = calTotal(calories);
            Console.WriteLine("TOTAL CALORIES: " + calExceed);
            if (calExceed > 300)
            {
                Console.WriteLine("!!!TOTAL CALORIES EXCEED 300!!!");
            }
            int stpNum;
            do
            {
                Console.WriteLine("Enter Number of Steps:");
            } while (!int.TryParse(Console.ReadLine(), out stpNum));

            steps = new string[stpNum];

            for (int a = 0; a < stpNum; a++)
            {
                Console.Write($"Steps#{a + 1}:");
                steps[a] = Console.ReadLine();
            }
        }
        public double calTotal(double[] calories)
        {
            double result = 0;
            for (int i = 0; i < calories.Length; i++)
            {
                result += calories[i];
            }
            return result;
        }
        public void RecipeDisplay()
        {
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"- {amount[i]}{units[i]} of {ingredients[i]}");
            }
            Console.WriteLine("Steps:");
            for (int a = 0; a < steps.Length; a++)
            {
                Console.WriteLine($"-{steps[a]}");
            }
            double result = 0;
            for (int i = 0; i < calories.Length; i++)
            {
                result += calories[i];
            }
            if (result > 300)
            {
                Console.WriteLine("!!!TOTAL CALORIES EXCEED 300!!!");
            }

        }
        public void RecipeScale(double scale)
        {
            for (int i = 0; i < amount.Length; i++)
            {
                amount[i] *= scale;
            }
        }
        public void ResetRecipe()
        {
            for (int i = 0; i < amount.Length; i++)
            {
                amount[i] /= 2;
            }
        }
        public void ClearRecipe()
        {
            ingredients = new String[0];
            amount = new double[0];
            units = new String[0];
            steps = new String[0];
        }
    }
}


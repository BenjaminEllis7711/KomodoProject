using _01_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    class UI
    {
        private MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.WriteLine("Komodo Cafe Menu Administrator");
                Console.WriteLine("Select from the following options:");
                Console.WriteLine("1. View Current Menu\n" +
                    "2. Add a new Meal\n" +
                    "3. Update a Meal\n" +
                    "4. Delete Existing Meal\n" +
                    "5. Exit\n");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        ViewMenu();
                        break;
                    case "2":
                    case "two":
                        AddToMenu();
                        break;
                    case "3":
                    case "three":
                        UpdateMenu();
                        break;
                    case "4":
                    case "four":
                        DeleteItem();
                        break;
                    case "5":
                    case "five":
                        menuRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;

                }
            }
        }
        public void ViewMenu()
        {
            Console.Clear();
            List<MenuItem> currentMenu = _repo.GetMenu();
            if (currentMenu.Count == 0)
            {
                Console.WriteLine("There is nothing currently on the menu.\n");
            }
            else
            {
                Console.WriteLine("Current Menu:\n");
                foreach (MenuItem menuView in currentMenu)
                {
                    Console.WriteLine($"Meal number: {menuView.MealNumber}\n" +
                        $"Meal Name: {menuView.MealName}\n" +
                        $"Description: {menuView.Description}\n");
                    Console.Write("Ingredients: ");
                    Console.Write(String.Join(", ", menuView.Ingredients));
                    Console.WriteLine($"\nPrice: ${menuView.Price}\n\n");
                }
            }
        }
        public void AddToMenu()
        {
            Console.Clear();
            MenuItem newItem = GetMealInfo();
            bool wasItemAdded = _repo.AddItemToDirectory(newItem);
            if (wasItemAdded == true)
            {
                Console.WriteLine("Meal was successfully added to menu.");
            }
            else Console.WriteLine("Unable to add meal. Please try again.");
        }
        public MenuItem GetMealInfo()
        {
            MenuItem newItem = new MenuItem();
            newItem.Ingredients = new List<string>();
            Console.WriteLine("What is the name of the meal?");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter a description for this meal:");
            newItem.Description = Console.ReadLine();
            Console.WriteLine("Enter what Meal Number this meal will have:");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price for this meal:");
            Console.Write("$");
            newItem.Price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the number of ingredients.");
            int numberOfIngredients = Convert.ToInt32(Console.ReadLine());
            for (int x = 1; x <= numberOfIngredients; x++)
            {
                Console.WriteLine($"Enter ingredient #{x}:");
                newItem.Ingredients.Add(Console.ReadLine());
            }
            return newItem;
        }
        public void UpdateMenu()
        {
            MenuItem newItem = new MenuItem();
            Console.WriteLine("Enter the meal number you wish to update.");
            int updateMealNumber = Convert.ToInt32(Console.ReadLine());
            newItem = GetMealInfo();
            bool wasUpdated = _repo.UpdateByNumber(updateMealNumber, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("Meal was successfully updated");
            }
            else Console.WriteLine("Unable to update, please try again.");
        }
        public void DeleteItem()
        {
            Console.WriteLine("Enter Meal Number of item you wish to delete.");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            bool wasDeleted = _repo.DeleteExistingItem(mealNumber);
            if (wasDeleted)
            {
                Console.WriteLine("Item was deleted. Press any key to continue.");
            }
            else Console.WriteLine("Unable to delete item. Press any key to continue.");
            Console.ReadKey();
        }
    }
}


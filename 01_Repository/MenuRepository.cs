using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Repository
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuItemDirectory = new List<MenuItem>();

        public List<MenuItem> GetMenu()
        {
            return _menuItemDirectory;
        }
        public bool AddItemToDirectory(MenuItem newItem)
        {
            int menuCount = _menuItemDirectory.Count();
            _menuItemDirectory.Add(newItem);
            bool wasItemAdded = (_menuItemDirectory.Count > menuCount) ? true : false;
            return wasItemAdded;
        }

        public MenuItem GetItemByNumber(int mealNumber)
        {
            foreach (MenuItem findMeal in _menuItemDirectory)
            {
                if (findMeal.MealNumber == mealNumber)
                {
                    return findMeal;
                }
            }
            return null;
        }

        public bool UpdateByNumber(int mealNumber, MenuItem newItem)
        {
            MenuItem oldMeal = GetItemByNumber(mealNumber);
            if (oldMeal != null)
            {
                oldMeal.MealName = newItem.MealName;
                oldMeal.MealNumber = newItem.MealNumber;
                oldMeal.Description = newItem.Description;
                oldMeal.Ingredients = newItem.Ingredients;
                oldMeal.Price = newItem.Price;
                return true;
            }
            else return false;
        }

        public bool DeleteExistingItem(int mealNumber)
        {
            MenuItem itemToDelete = GetItemByNumber(mealNumber);
            if (itemToDelete != null)
            {
                _menuItemDirectory.Remove(itemToDelete);
                return true;
            }
            else return false;
        }
    }
}

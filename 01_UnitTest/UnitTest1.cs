using _01_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBool()
        {
            MenuItem test = new MenuItem();
            MenuRepository test2 = new MenuRepository();

            bool addResult = test2.AddItemToDirectory(test);

            Assert.IsTrue(addResult);
        }

        public void GetItemByMealNumber_ShouldGetCorrectItem()
        {
            List<string> Test = new List<string>();
            Test.Add("test");
            MenuItem item = new MenuItem(1, "testMeal", "test", Test, 1.55m);
            MenuRepository repo = new MenuRepository();

            MenuItem directory = repo.GetItemByNumber(item.MealNumber)
        }
    }
}

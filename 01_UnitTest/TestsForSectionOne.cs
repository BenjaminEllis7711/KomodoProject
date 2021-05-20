using _01_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_UnitTests
{
    [TestClass]
    public class TestsForSectionOne
    {
        private MenuItem _item = new MenuItem();
        private MenuRepository _repo = new MenuRepository();

        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBool()
        {
            MenuItem test = new MenuItem();
            MenuRepository test2 = new MenuRepository();

            bool addResult = test2.AddItemToDirectory(test);

            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetItemByMealNumber_ShouldGetCorrectItem()
        {
            SeedMenuAndTestAddItem_ShouldGetCorrectBool();
            _item = _repo.GetItemByNumber(1);

            Assert.AreEqual(_item.Price, 1.50m);
           
        }
        [TestMethod]
        public void SeedMenuAndTestAddItem_ShouldGetCorrectBool()
        {
            List<string> seedList = new List<string>();
            seedList.Add("test");
            seedList.Add("test2");
            MenuItem testItem = new MenuItem(1, "Test Meal 1", "Test Description", seedList, 1.50m);
            bool wasAdded = _repo.AddItemToDirectory(testItem);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void TestDelete_ShouldGetCorrectBool()
        {
            SeedMenuAndTestAddItem_ShouldGetCorrectBool();
            bool wasDeleted = _repo.DeleteExistingItem(1);

            Assert.IsTrue(wasDeleted);
        }
        [TestMethod]
        public void UpdateTest_ShouldGetCorrectBool()
        {
            SeedMenuAndTestAddItem_ShouldGetCorrectBool();
            List<string> seedList = new List<string>();
            seedList.Add("test3");
            seedList.Add("test4");
            MenuItem testItem2 = new MenuItem(1, "Test Meal 2", "Test Description", seedList, 2.50m);
            bool wasUpdated = _repo.UpdateByNumber(1, testItem2);

            Assert.IsTrue(wasUpdated);
        }
    }
}

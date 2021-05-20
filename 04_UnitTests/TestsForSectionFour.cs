using _04_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _04_UnitTests
{
    [TestClass]
    public class TestsForSectionFour
    {
        private OutingRepository _repo = new OutingRepository();
        [TestMethod]
        public void TestTotalCost_ShouldEqualTotalFromSeed()
        {
            TestAddAndSeedOutings_ShouldGetCorrectBool();
            decimal totalCost = _repo.GetTotalCost();
            Assert.AreEqual(totalCost, 22000);
        }
        [TestMethod]
        public void TestAddAndSeedOutings_ShouldGetCorrectBool()
        {
            OutingItem testItem = new OutingItem(EventType.Bowling, 500, new DateTime(2020, 04, 07), 6000.00m);
            OutingItem testItem2 = new OutingItem(EventType.Concert, 1000, new DateTime(2020, 04, 15), 3500.00m);
            OutingItem testItem3 = new OutingItem(EventType.Golf, 150, new DateTime(2020, 05, 11), 5000.00m);
            OutingItem testItem4 = new OutingItem(EventType.Bowling, 150, new DateTime(2020, 04, 11), 7500.00m);
            bool wasAdded = _repo.AddOuting(testItem);
            wasAdded = _repo.AddOuting(testItem2);
            wasAdded = _repo.AddOuting(testItem3);
            wasAdded = _repo.AddOuting(testItem4);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void TestCostByType_ShouldEqualSeed()
        {
            TestAddAndSeedOutings_ShouldGetCorrectBool();
            decimal costByType = _repo.GetCostByType(1);
            Assert.AreEqual(costByType, 13500);
        }
    }
}

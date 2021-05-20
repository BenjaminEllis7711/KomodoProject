using _03_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_UnitTests
{
    [TestClass]
    public class TestsForSectionThree
    {
        private readonly BadgeRepository _repo = new BadgeRepository();
        [TestMethod]
        public void TestAddBadge_ShouldGetCorrectBool()
        {
            List<string> test = new List<string>();
            test.Add("A1");
            bool wasAdded = _repo.AddBadge(1, test);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void TestSeedAndDisplay_ShouldCountThree()
        {
            _repo.SeedBadgeList();
            Dictionary<int, List<string>> test = new Dictionary<int, List<string>>();
            test = _repo.DisplayAllBadges();
            Assert.AreEqual(test.Count, 3);
        }
        [TestMethod]
        public void TestGetDoorList_ShouldGetCorrectDoor()
        {
            _repo.SeedBadgeList();
            List<string> test = new List<string>();
            test = _repo.GetDoorListByID(12345);
            string testString = test[0];
            Assert.AreEqual(testString, "A7");
        }
        [TestMethod]
        public void TestAddDoor_CountShouldBeDifferent()
        {
            _repo.SeedBadgeList();
            List<string> testList = new List<string>();
            testList = _repo.GetDoorListByID(12345);
            int startCounter = testList.Count;
            string doorToAdd = "Z99";
            _repo.AddDoor(12345, doorToAdd);
            testList = _repo.GetDoorListByID(12345);
            Assert.AreNotEqual(startCounter, testList.Count);
        }
        [TestMethod]
        public void TestRemoveDoor_CountShouldBeDifferent()
        {
            _repo.SeedBadgeList();
            List<string> testList = new List<string>();
            testList = _repo.GetDoorListByID(12345);
            int startCounter = testList.Count;
            string doorToRemove = "A7";
            _repo.RemoveDoor(12345, doorToRemove);
            testList = _repo.GetDoorListByID(12345);
            Assert.AreNotEqual(startCounter, testList.Count);
        }
    }
}

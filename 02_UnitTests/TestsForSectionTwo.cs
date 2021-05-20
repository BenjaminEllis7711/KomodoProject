using _02_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_UnitTests
{
    [TestClass]

    public class TestsForSectionTwo
    {

        private ClaimItem _item = new ClaimItem();
        private ClaimRepository _repo = new ClaimRepository();

        [TestMethod]
        public void TestAddClaim_ShouldReturnCorrectBool()
        {
            ClaimItem newItem = new ClaimItem(4, ClaimType.Car, "Test", 150.00m, new DateTime(2020, 01, 01), new DateTime(2020, 01, 11));
            bool wasAdded = _repo.AddClaimToDirectory(newItem);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void TestSeedandDisplayClaims_CountShouldBeThree()
        {
            _repo.SeedClaimDirectory();
            Queue<ClaimItem> test = new Queue<ClaimItem>();
            test = _repo.DisplayClaims();
            Assert.AreEqual(test.Count, 3);
        }
        [TestMethod]
        public void TestDequeue_ShouldReturnCorrectBool()
        {
            _repo.SeedClaimDirectory();
            bool wasDequeued = _repo.HandleNextItem();
            Assert.IsTrue(wasDequeued);
        }
        [TestMethod]
        public void TestPeek_ClaimIDShouldBeOne()
        {
            _repo.SeedClaimDirectory();
            ClaimItem test = new ClaimItem();
            test = _repo.DisplayNextClaim();
            Assert.AreEqual(test.ClaimId, 1);
        }
        [TestMethod]
        public void TestHandleNextClaim_ShouldGetCorrectBool()
        {
            _repo.SeedClaimDirectory();
            bool wasHandled = _repo.HandleNextItem();
            Assert.IsTrue(wasHandled);
        }
    }
}

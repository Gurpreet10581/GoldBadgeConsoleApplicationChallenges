using System;
using System.Collections;
using System.Collections.Generic;
using _02_KClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_KClaimUnitTest
{
    [TestClass]
    public class ClaimUnitTest
    {
        ClaimRepo _repoTest = new ClaimRepo();
        Queue queueList = new Queue();

        [TestMethod]
        public void ListOfClaims()
        {
            ClaimContent testSecond = new ClaimContent(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 18), true);
            _repoTest.EnterNewClaim(testSecond);

            
            Queue<ClaimContent> queueListTest=_repoTest.GetListOfClaims();// no arrange needed because we are just calling the queue

            bool testagian = queueListTest.Contains(testSecond);

            Assert.IsTrue(testagian);

        }
        
        [TestMethod]
        public void EnterNewClaimTest()
        {
            ClaimContent content = new ClaimContent();
           

            bool addClaim = _repoTest.EnterNewClaim(content);

            Assert.IsTrue(addClaim);

        }
        [TestMethod]
        
        public void NextClaimTest()
        {
            //Arrange
            ClaimContent nextclaim = new ClaimContent(3, ClaimType.Theft, "Stolen pancakes", 1000.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);
            Queue<ClaimContent> localQueue = _repoTest.GetListOfClaims();// everything done here gets saved in the repo queue created a local queue
            localQueue.Clear();// empting local queue
            localQueue.Enqueue(nextclaim);

           //Act

            ClaimContent actual = _repoTest.OpenNextClaim();
            ClaimContent expected = nextclaim;

            //Assert

            Assert.AreEqual(expected, actual);

        }

       

        [TestMethod]
        public void IsValidClaimTest()
        {
            ClaimContent claimOne = new ClaimContent(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            ClaimContent claimTwo = new ClaimContent(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 18), true);
            ClaimContent claimThree = new ClaimContent(3, ClaimType.Theft, "Stolen pancakes", 1000.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _repoTest.IsValid(claimOne);
            bool actual = _repoTest.IsValid(claimOne);
            bool expected = true;
            Assert.AreEqual(expected, actual);

            

            _repoTest.IsValid(claimTwo);
            bool actualTwo = _repoTest.IsValid(claimTwo);
            bool expectTwo = true;
            Assert.AreEqual(expectTwo, actualTwo);

            _repoTest.IsValid(claimThree);
            bool actualThree = _repoTest.IsValid(claimThree);
            bool expectthree = false;   
            Assert.AreEqual(expectthree, actualThree);

        }

        [TestMethod]
        public void AddNewClaimtoQueueTest()
        {
            ClaimContent claimOne = new ClaimContent(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
          

            _repoTest.EnterNewClaim(claimOne);
            int expected = 1;
            int actual = _repoTest.GetListOfClaims().Count;
            Assert.AreEqual(expected, actual);
        }



    }
}

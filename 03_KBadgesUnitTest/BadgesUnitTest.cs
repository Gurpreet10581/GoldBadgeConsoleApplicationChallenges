using System;
using System.Collections.Generic;
using _03_KBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_KBadgesUnitTest
{
    [TestClass]
    public class BadgesUnitTest
    {
        BadgesRepo _repo = new BadgesRepo();
        
        
        [TestMethod]
        public void GetContentByBadgeId_Test()
        {
            

        }

        [TestMethod]
        public void CreateNewBadge_Test()
        {
           
        }

        [TestMethod]
        public void ListOfBadgesAndDoors_Test()
        {
            BadgesContent listItems = new BadgesContent(22345, new List<string> { "A1", "A4", "B1", "B2" });
            _repo.ListOfBadgesAndDoors(listItems);
            //act
            //Dictionary<int, List<string>> dictionaryTest = _repo.ListOfBadgesAndDoors();
            //Queue<ClaimContent> queueListTest = _repoTest.GetListOfClaims();// no arrange needed because we are just calling the queue

            //bool testagian = dictionaryTest.ContainsKey(listItems);
            //assert

            //Assert.IsTrue(testagian);
        }

        [TestMethod]
        public void UpdateDoorForBadge_Test()
        {

        }
        [TestMethod]
        public void RemoveDoorsFromBadge_Test()
        {

        }
    }
}

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
            //arrange
            _repo.seed();

            //act
            List<string> doors = _repo.GetDoorsByBadgeId(1);
            int actual=doors.Count;
            int expected = 4;


            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateNewBadge_Test()
        {
            //arrange
            BadgesContent content = new BadgesContent();

            //act
            bool addBadge = _repo.CreateNewBadge(content);
            //assert
            Assert.IsTrue(addBadge);
        }

        [TestMethod]
        public void ListOfBadgesAndDoors_Test()
        {
            BadgesContent listItems = new BadgesContent(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Dictionary<int,List<string>> unitTestDict= _repo.ListOfBadgesAndDoors();
        }

        
        [TestMethod]
        public void RemoveDoorsFromBadge_Test()
        {
            //arrange
            // BadgesContent content = new BadgesContent();
            _repo.seed();
            //act
            bool removeDoor = _repo.RemoveDoorsFromBadge(1, "A7");
            //assert
            Assert.IsTrue(removeDoor);
        }
        [TestMethod]
        public void AddDoorsToBadge_Test()
        {
            _repo.seed();

            //act
            bool addDoor = _repo.AddDoorsToBadge(2, "B12");
            //assert
            Assert.IsTrue(addDoor);
        }
       
    }
}

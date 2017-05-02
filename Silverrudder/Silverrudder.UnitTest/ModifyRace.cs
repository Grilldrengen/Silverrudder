using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using BusinessLayer;


namespace UI.UnitTest
{
    [TestClass]
    public class ModifySailRace
    {        
        Captain captain = new Captain();
        CaptainRepository captainRepository = new CaptainRepository();   
        
        [TestMethod]
        public void ModifyCaptain_Create_OneCaptainObjectCreated()
        {
            captainRepository.Create(captain);
            int listCount = CaptainList.Instance.captainList.Count;

            Assert.AreEqual(captain, CaptainList.Instance.captainList[listCount - 1]);
        }

        [TestMethod]
        public void ModifyCaptain_Delete_CaptainObjectDeleted()
        {
            CaptainList.Instance.captainList.Add(captain = new Captain());

            captainRepository.Delete(captain);

            Assert.IsFalse(CaptainList.Instance.captainList.Contains(captain));
        }

        [TestMethod]
        public void ModifyCaptain_Modify_CanChangeName()
        {
            CaptainList.Instance.captainList.Add(captain = new Captain("test"));            

            bool result = captainRepository.Modify(captain, CaptainProperties.Name, "Changed");

            Assert.AreEqual(captain.Name, "Changed");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ModifyCaptain_Modify_CanChangeCountry()
        {
            bool result = captainRepository.Modify(captain, CaptainProperties.Country, "DEN");

            Assert.AreEqual(captain.Country, "DEN");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ModifyCaptain_Modify_CanChangeParticipantNumber()
        {
            bool result = captainRepository.Modify(captain, CaptainProperties.ParticipantNumber, "1234");
            Assert.AreEqual(captain.ParticipantNumber, 1234);
            Assert.IsTrue(result);
        }

        [TestCleanup]
        public void CleanUp_ClearList()
        {
            CaptainList.Instance.captainList.Clear();
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using BusinessLayer;


namespace Silverrudder.UnitTest
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

        [TestCleanup]
        public void CleanUp_OneCaptainObjectCreated()
        {
            CaptainList.Instance.captainList.Remove(captain);
        }

        [TestMethod]
        public void ModifyCaptain_Delete_CaptainObjectDeleted()
        {
            CaptainList.Instance.captainList.Add(captain = new Captain());

            captainRepository.Delete(captain);

            Assert.IsFalse(CaptainList.Instance.captainList.Contains(captain));
        }

        [TestMethod]
        public void ModifyCaptain_Modify_NameChanged()
        {
            CaptainList.Instance.captainList.Add(captain = new Captain());

            CaptainList.Instance.captainList[0].Name = "test";
            captain = CaptainList.Instance.captainList[0];

            captainRepository.Modify(captain);

            Assert.AreEqual("testChanged", captain);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using BusinessLayer;


namespace UI.UnitTest
{
    [TestClass]
    public class ModifySailRace
    {        
        Participant Participant = new Participant();
        ParticipantRepository ParticipantRepository = new ParticipantRepository();   
        
        [TestMethod]
        public void ModifyParticipant_Create_OneParticipantObjectCreated()
        {
            ParticipantRepository.Create(Participant);
            int listCount = ParticipantList.Instance.ParticipantList.Count;

            Assert.AreEqual(Participant, ParticipantList.Instance.ParticipantList[listCount - 1]);
        }

        [TestMethod]
        public void ModifyParticipant_Delete_ParticipantObjectDeleted()
        {
            ParticipantList.Instance.ParticipantList.Add(Participant = new Participant());

            ParticipantRepository.Delete(Participant);

            Assert.IsFalse(ParticipantList.Instance.ParticipantList.Contains(Participant));
        }

        [TestMethod]
        public void ModifyParticipant_Modify_CanChangeName()
        {
            ParticipantList.Instance.ParticipantList.Add(Participant = new Participant("test"));            

            bool result = ParticipantRepository.Modify(Participant, ParticipantProperties.Name, "Changed");

            Assert.AreEqual(Participant.Name, "Changed");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ModifyParticipant_Modify_CanChangeCountry()
        {
            bool result = ParticipantRepository.Modify(Participant, ParticipantProperties.Country, "DEN");

            Assert.AreEqual(Participant.Country, "DEN");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ModifyParticipant_Modify_CanChangeParticipantNumber()
        {
            bool result = ParticipantRepository.Modify(Participant, ParticipantProperties.ParticipantNumber, "1234");
            Assert.AreEqual(Participant.ParticipantNumber, 1234);
            Assert.IsTrue(result);
        }

        [TestCleanup]
        public void CleanUp_ClearList()
        {
            ParticipantList.Instance.ParticipantList.Clear();
        }
    }
}

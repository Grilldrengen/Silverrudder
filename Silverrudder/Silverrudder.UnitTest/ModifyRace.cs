using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using BusinessLayer;
using DataAccesLayer;


namespace UI.UnitTest
{
    [TestClass]
    public class ModifySailRace
    {        
        Participant Participant = new Participant();
        ParticipantRepository ParticipantRepository = new ParticipantRepository();
        ImportCSVParticipantsFile importCSVParticipantsFile = new ImportCSVParticipantsFile();
        SortParticipantAssignedCategori sortParticipantAssignedCategori = new SortParticipantAssignedCategori();

        [TestMethod]
        public void ModifyParticipant_Create_OneParticipantObjectCreated()
        {
            ParticipantRepository.Create(Participant);
            int listCount = ParticipantList.Instance.participantList.Count;

            Assert.AreEqual(Participant, ParticipantList.Instance.participantList[listCount - 1]);
        }

        [TestMethod]
        public void ModifyParticipant_Delete_ParticipantObjectDeleted()
        {
            ParticipantList.Instance.participantList.Add(Participant = new Participant());

            ParticipantRepository.Delete(Participant);

            Assert.IsFalse(ParticipantList.Instance.participantList.Contains(Participant));
        }

        [TestMethod]
        public void ModifyParticipant_Modify_CanChangeName()
        {
            ParticipantList.Instance.participantList.Add(Participant = new Participant("test"));            

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

        ////Virker kun lokalt, ellers ændr stien
        //[TestMethod]
        //public void ModifyParticipant_FindNewCategories_SevenCategoriesFound()
        //{
        //    importCSVParticipantsFile.ReadCSVFile(@"C:\Users\Christian\Desktop\Silverrudder\Participants.csv");
        //    sortParticipantAssignedCategori.FindNewCategories();

        //    Assert.AreEqual(7, CategoryList.Instance.categoryList.Count);

        //}

        //Virker kun lokalt, ellers ændr stien
        [TestMethod]
        public void ModifyParticipant_AssignParticipantsToCategories_39ParticipantsFoundInCategory()
        {
            importCSVParticipantsFile.ReadCSVFile(@"C:\Users\Christian\Desktop\Silverrudder\Participants.csv");
            sortParticipantAssignedCategori.FindNewCategories();

            int count = 0;
            for (int i = 0; i < CategoryList.Instance.categoryList.Count; i++)
            {
                if (CategoryList.Instance.categoryList[i].Name.Equals("Keelboats Extra Large"))
                {
                    count = CategoryList.Instance.categoryList[i].Participants.Count;
                }
            }
            Assert.AreEqual(39, count);
        }

        [TestCleanup]
        public void CleanUp_ClearList()
        {
            ParticipantList.Instance.participantList.Clear();
        }
    }
}

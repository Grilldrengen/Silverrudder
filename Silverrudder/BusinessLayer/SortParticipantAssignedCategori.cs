using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public class SortParticipantAssignedCategori
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        List<Category> categoryList = new List<Category>();
        ObservableCollection<Participant> participantList = new ObservableCollection<Participant>();

        internal void StartSorting()
        {
            participantList = ParticipantRepository.GetAll();
            FindNewCategories(participantList);
        }

        private void FindNewCategories(ObservableCollection<Participant> allParticipants)
        {
            List<string> categories = new List<string>();

            foreach (Participant participant in allParticipants)
            {
                if (!categories.Contains(participant.CategoryAssignedByParticipant))
                {
                    categories.Add(participant.CategoryAssignedByParticipant);
                }
            }
            AddFoundCategories(categories);
        }

        private void AddFoundCategories(List<string> foundCategoriesList)
        {
            foreach (string categoryDescription in foundCategoriesList)
            {
                Category category = new Category(categoryDescription);
                categoryRepository.Create(category);
            }
            AssignParticipantsToCategories();
        }

        private void AssignParticipantsToCategories()
        {
            //categoryList = CategoryList.Instance.categoryList;
            //participantList = ParticipantList.Instance.participantList;

            //for (int i = 0; i < categoryList.Count; i++)
            //{
            //    for (int j = 0; j < participantList.Count; j++)
            //    {
            //        if (!(categoryList[i].Participants.Contains(participantList[j])))
            //        {
            //            if (categoryList[i].Name.Equals(participantList[j].Name))
            //                categoryList[i].Participants.Add(participantList[j]);                       
            //        }
            //    }
            //}
        }
    }
}

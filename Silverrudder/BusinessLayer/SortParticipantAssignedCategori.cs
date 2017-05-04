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
        internal void StartSorting()
        {
            FindNewCategories(ParticipantList.Instance.participantList);
        }

        private void FindNewCategories(ObservableCollection<Participant> participants)
        {
            List<string> categories = new List<string>();

            foreach (Participant participant in participants)
            {
                if (!categories.Contains(participant.Category))
                {
                    categories.Add(participant.Category);
                }
            }
            AddFoundCategories(categories);
        }

        private void AddFoundCategories(List<string> foundCategoriesList)
        {
            foreach (string categoryDescription in foundCategoriesList)
            {
                Category category = new Category(categoryDescription);
                CategoryList.Instance.categoryList.Add(category);
            }
            SortParticipantAssignedCategories();
        }

        private void SortParticipantAssignedCategories()
        {
            foreach (Category category in CategoryList.Instance.categoryList)
            {
                foreach (Participant participant in ParticipantList.Instance.participantList)
                {
                    if (category.Name.Equals(participant.Category))
                        category.Participants.Add(participant);
                }
            }
        }
    }
}
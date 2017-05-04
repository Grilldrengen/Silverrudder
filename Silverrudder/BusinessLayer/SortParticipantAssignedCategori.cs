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
            FindNewCategories(ParticipantRepository.Instance.list);
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
                CategoryRepository.Instance.list.Add(category);
            }
            SortParticipantAssignedCategories();
        }

        private void SortParticipantAssignedCategories()
        {
            foreach (Category category in CategoryRepository.Instance.list)
            {
                foreach (Participant participant in ParticipantRepository.Instance.list)
                {
                    if (category.Name.Equals(participant.Category))
                        category.Participants.Add(participant);
                }
            }
        }
    }
}
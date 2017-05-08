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
            CreateNewCategories(ParticipantRepository.Instance.list);
        }

        private void CreateNewCategories(ObservableCollection<Participant> participants)
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

        internal void SplitCategory()
        {
            for (int i = 0; i < CategoryRepository.Instance.list.Count; i++)
            {
                Category category1 = new Category(CategoryRepository.Instance.list[i].Name + " 1");
                Category category2 = new Category(CategoryRepository.Instance.list[i].Name + " 2");

                int participantsTotal = CategoryRepository.Instance.list[i].Participants.Count;
                int participantsAmountDividedByTwo = participantsTotal / 2;

                for (int j = 0; j < participantsAmountDividedByTwo; j++)
                {
                    category1.Participants.Add(CategoryRepository.Instance.list[i].Participants[j]);
                }

                for (int j = participantsAmountDividedByTwo; j < participantsTotal; j++)
                {
                    category2.Participants.Add(CategoryRepository.Instance.list[i].Participants[j]);
                }

                CategoryRepository.Instance.Create(category1);
                CategoryRepository.Instance.Create(category2);
                CategoryRepository.Instance.Delete(CategoryRepository.Instance.list[i]);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer
{
    public class SortParticipantAssignedCategori
    {
        ParticipantRepository participantRepository = new ParticipantRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        List<Category> categoryList = new List<Category>();
        List<Participant> participantList;

        public void FindNewCategories()
        {
            participantList = participantRepository.GetAll();
            List<string> categories = new List<string>();

            foreach (Participant participant in participantList)
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
            //participantList = participantRepository.GetAll();
            //categoryList = categoryRepository.GetAll();
            foreach (Category category in CategoryList.Instance.categoryList)
            {
                foreach (Participant participant in ParticipantList.Instance.participantList)
                {
                    if (participant.CategoryAssignedByParticipant.Equals(category.Name))
                        category.participants.Add(participant);
                }
            }
        }
    }
}

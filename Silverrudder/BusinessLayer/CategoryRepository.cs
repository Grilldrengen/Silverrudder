﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Collections.ObjectModel;

namespace BusinessLayer
{
    public enum CategoryProperties { Name, MinLength, MaxLength, StartTime };

    public class CategoryRepository : IRepository<Category, CategoryProperties, string>
    {
        private static readonly CategoryRepository _instance = new CategoryRepository();

        public static CategoryRepository Instance
        {
            get
            {
                return _instance;
            }
        }
        public ObservableCollection<Category> list = new ObservableCollection<Category>();


        public void Create(Category category)
        {
            Instance.list.Add(category);
        }

        public void Delete(Category category)
        {
            Instance.list.Remove(category);
        }

        public bool Modify(Category category, CategoryProperties property, string newValue)
        {
            bool result;
            switch (property)
            {
                case CategoryProperties.Name:
                    category.Name = newValue;
                    return true;

                case CategoryProperties.StartTime:
                    result = TryParseStringToDateTime(newValue);
                    if (result == false)
                        return false;
                    else 
                    return true;

                default:
                    return false;
            }
        }

        public ObservableCollection<Category> GetAll()
        {
            return Instance.list;
        }


        public void SplitCategory(Category category)
        {
            Category category1 = new Category(category.Name + " 1");
            Category category2 = new Category(category.Name + " 2");

            int participantsTotal = category.Participants.Count;
            int participantsAmountDividedByTwo = participantsTotal / 2;

            for (int j = 0; j < participantsAmountDividedByTwo; j++)
            {
                category1.Participants[j].Category = category1.Name;

                category1.Participants.Add(category.Participants[j]);
            }

            for (int j = participantsAmountDividedByTwo; j < participantsTotal; j++)
            {
                category2.Participants[j].Category = category2.Name;

                category2.Participants.Add(category.Participants[j]);
            }

            Instance.Create(category1);
            Instance.Create(category2);
            Instance.Delete(category);
        }

        private bool TryParseStringToFloat(string value)
        {
            float length;
            bool res = float.TryParse(value, out length);

            if (res == true)
                return true;

            else return false;
        }

        private bool TryParseStringToDateTime(string value)
        {
            DateTime startTime;
            bool res = DateTime.TryParse(value, out startTime);

            if (res == true)
                return true;

            else return false;
        }
    }
}

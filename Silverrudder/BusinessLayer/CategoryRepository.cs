using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer
{
    public enum CategoryProperties { Name, MinLength, MaxLength, StartTime };

    public class CategoryRepository : IRepository<Category, CategoryProperties, string>
    {

        public void Create(Category category)
        {
            CategoryList.Instance.categoryList.Add(category);
        }

        public void Delete(Category category)
        {
            CategoryList.Instance.categoryList.Remove(category);
        }

        public bool Modify(Category category, CategoryProperties property, string newValue)
        {
            bool result;
            switch (property)
            {
                case CategoryProperties.Name:
                    category.Name = newValue;
                    return true;
                case CategoryProperties.MinLength:
                    result = TryParseStringToFloat(newValue);
                    if (result == false)
                        return false;
                    else category.MinLength = float.Parse(newValue);
                    return true;
                case CategoryProperties.MaxLength:
                    result = TryParseStringToFloat(newValue);
                    if (result == false)
                        return false;
                    else category.MaxLength = float.Parse(newValue);
                    return true;
                case CategoryProperties.StartTime:
                    result = TryParseStringToDateTime(newValue);
                    if (result == false)
                        return false;
                    else category.StartTime = Convert.ToDateTime(newValue);
                    return true;
                default:
                    return false;
            }
        }

        public List<Category> GetAll()
        {
            return CategoryList.Instance.categoryList;
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

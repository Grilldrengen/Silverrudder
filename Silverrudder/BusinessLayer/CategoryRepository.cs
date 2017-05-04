using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLayer
{
    public class CategoryRepository
    {

        public static void Create(Category category)
        {
            CategoryList.Instance.categoryList.Add(category);
        }

        public static void Delete(Category category)
        {
            CategoryList.Instance.categoryList.Remove(category);
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

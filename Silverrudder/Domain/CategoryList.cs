using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryList
    {
        private static readonly CategoryList _instance = new CategoryList();

        public static CategoryList Instance
        {
            get
            {
                return _instance;
            }
        }
        public List<Category> categoryList = new List<Category>();

        public CategoryList()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

        public interface IRepository<T, X, Y>
        {
            void Create(T entity);
            void Delete(T entity);
            bool Modify(T obj, X property, Y modifyValue);
            //List<T> GetAll();
            ////IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
            ////IQueryable<T> GetAll();
            ////T GetById(int id);
        }
    
}

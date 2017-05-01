using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Delete(T entity);
        void Modify(T entity);
        ////IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        ////IQueryable<T> GetAll();
        ////T GetById(int id);
    }
}

using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

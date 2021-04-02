using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandLogic
    {
        Task<Brand> GetByIdAsync(int id);
        Task<List<Brand>> GetListAsync(Expression<Func<Brand, bool>> filter = null);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}

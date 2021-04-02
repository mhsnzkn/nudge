using Business.Utility;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandBusiness
    {
        Task<Brand> GetByIdAsync(int id);
        Task<List<Brand>> GetListAsync(Expression<Func<Brand, bool>> filter = null);
        Task<ResultModel> Add(Brand brand);
        Task<ResultModel> Delete(Brand brand);
        Task<ResultModel> Update(Brand brand);
    }
}

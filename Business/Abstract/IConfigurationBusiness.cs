using Business.Utility;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConfigurationBusiness
    {
        Task<Configuration> GetByIdAsync(int id);
        Task<List<Configuration>> GetListAsync(Expression<Func<Configuration, bool>> filter = null);
        Task<ResultModel> Add(Configuration configuration);
        Task<ResultModel> Delete(Configuration configuration);
        Task<ResultModel> Update(Configuration configuration);
    }
}

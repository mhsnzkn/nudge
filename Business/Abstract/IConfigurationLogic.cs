using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConfigurationLogic
    {
        Task<Configuration> GetByIdAsync(int id);
        Task<List<Configuration>> GetListAsync(Expression<Func<Configuration, bool>> filter = null);
        void Add(Configuration configuration);
        void Delete(Configuration configuration);
        void Update(Configuration configuration);
    }
}

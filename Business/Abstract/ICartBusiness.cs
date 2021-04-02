using Business.Utility;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartBusiness
    {
        Task<Cart> GetByIdAsync(int id);
        Task<List<Cart>> GetListAsync(Expression<Func<Cart, bool>> filter = null);
        Task<ResultModel> Add(Cart cart);
        Task<ResultModel> Delete(Cart cart);
        Task<ResultModel> Update(Cart cart);
    }
}

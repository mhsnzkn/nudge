using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartLogic
    {
        Task<Cart> GetByIdAsync(int id);
        Task<List<Cart>> GetListAsync(Expression<Func<Cart, bool>> filter = null);
        void Add(Cart cart);
        void Delete(Cart cart);
        void Update(Cart cart);
    }
}

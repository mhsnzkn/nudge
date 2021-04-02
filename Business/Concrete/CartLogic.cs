using Business.Abstract;
using DataAccess.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartLogic : ICartLogic
    {
        private readonly IUnitOfWork uow;

        public CartLogic(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Add(Cart Cart)
        {
            uow.Cart.Add(Cart);
        }

        public void Delete(Cart Cart)
        {
            uow.Cart.Delete(Cart);
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await uow.Cart.GetByIdAsync(id);
        }

        public async Task<List<Cart>> GetListAsync(Expression<Func<Cart, bool>> filter = null)
        {
            return await uow.Cart.Get(filter).ToListAsync();
        }

        public void Update(Cart Cart)
        {
            uow.Cart.Update(Cart);
        }
    }
}

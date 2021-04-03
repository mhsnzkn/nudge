using Business.Abstract;
using Business.Utility;
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
    public class CartBusiness : ICartBusiness
    {
        private readonly IUnitOfWork uow;

        public CartBusiness(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<ResultModel> Add(Cart Cart)
        {
            var result = new ResultModel();
            try
            {
                if (await uow.Cart.IsExistAsync(Cart))
                {
                    result.SetError("The Item Already Exists");
                    return result;
                }
                uow.Cart.Add(Cart);
                await uow.SaveAsync();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            return result;
        }

        public async Task<ResultModel> Delete(Cart Cart)
        {
            uow.Cart.Delete(Cart);
            await uow.SaveAsync();
            return new ResultModel();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await uow.Cart.GetByIdAsync(id);
        }

        public async Task<List<Cart>> GetListAsync(Expression<Func<Cart, bool>> filter = null)
        {
            return await uow.Cart.Get(filter).Include(a=>a.Brand).Include(a => a.Ram).Include(a => a.Colour).ToListAsync();
        }

        public async Task<ResultModel> Update(Cart Cart)
        {
            uow.Cart.Update(Cart);
            await uow.SaveAsync();
            return new ResultModel();
        }
    }
}

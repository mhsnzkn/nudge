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
    public class BrandBusiness : IBrandBusiness
    {
        private readonly IUnitOfWork uow;

        public BrandBusiness(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<ResultModel> Add(Brand brand)
        {
            var result = new ResultModel();
            try
            {
                if(await uow.Brand.IsExist(brand))
                {
                    result.SetError("The Brand Already Exists");
                    return result;
                }
                uow.Brand.Add(brand);
                await uow.SaveAsync();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }
            
            return result;
        }

        public async Task<ResultModel> Delete(Brand Brand)
        {
            uow.Brand.Delete(Brand);
            await uow.SaveAsync();
            return new ResultModel();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await uow.Brand.GetByIdAsync(id);
        }

        public async Task<List<Brand>> GetListAsync(Expression<Func<Brand, bool>> filter = null)
        {
            return await uow.Brand.Get(filter).ToListAsync();
        }

        public async Task<ResultModel> Update(Brand Brand)
        {
            uow.Brand.Update(Brand);
            await uow.SaveAsync();
            return new ResultModel();
        }
    }
}

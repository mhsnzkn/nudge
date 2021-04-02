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
    public class BrandLogic : IBrandLogic
    {
        private readonly IUnitOfWork uow;

        public BrandLogic(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Add(Brand Brand)
        {
            uow.Brand.Add(Brand);
        }

        public void Delete(Brand Brand)
        {
            uow.Brand.Delete(Brand);
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await uow.Brand.GetByIdAsync(id);
        }

        public async Task<List<Brand>> GetListAsync(Expression<Func<Brand, bool>> filter = null)
        {
            return await uow.Brand.Get(filter).ToListAsync();
        }

        public void Update(Brand Brand)
        {
            uow.Brand.Update(Brand);
        }
    }
}

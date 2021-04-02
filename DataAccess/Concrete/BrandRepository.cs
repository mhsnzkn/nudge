using DataAccess.Abstract;
using DataAccess.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BrandRepository : RepositoryBase<Brand, AppDbContext>, IBrandRepository
    {
        private readonly AppDbContext context;

        public BrandRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> IsExist(Brand brand)
        {
            return await context.Brands.AnyAsync(a => a.Name == brand.Name);
        }
    }
}

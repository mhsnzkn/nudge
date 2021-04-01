using DataAccess.Abstract;
using DataAccess.Base;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class BrandRepository : RepositoryBase<Brand, AppDbContext>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {

        }
    }
}

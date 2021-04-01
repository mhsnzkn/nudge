using DataAccess.Abstract;
using DataAccess.Base;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CartRepository : RepositoryBase<Cart, AppDbContext>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {

        }
    }
}

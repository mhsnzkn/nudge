using DataAccess.Abstract;
using DataAccess.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CartRepository : RepositoryBase<Cart, AppDbContext>, ICartRepository
    {
        private readonly AppDbContext context;

        public CartRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> IsExistAsync(Cart cart)
        {
            return await context.Carts.AnyAsync(a => a.BrandId == cart.BrandId && a.ColourId == cart.ColourId && a.DiskId == cart.DiskId && a.RamId == cart.RamId);
        }
    }
}

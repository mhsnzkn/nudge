using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;

        }
        private IBrandRepository _brand;
        public IBrandRepository Brand
        {
            get
            {
                if (_brand == null)
                {
                    _brand = new BrandRepository(context);
                }

                return _brand;
            }
        }

        private IConfigurationRepository _configuration;
        public IConfigurationRepository Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationRepository(context);
                }

                return _configuration;
            }
        }

        private ICartRepository _cart;
        public ICartRepository Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(context);
                }

                return _cart;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

using DataAccess.Abstract;
using DataAccess.Base;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ConfigurationRepository : RepositoryBase<Configuration, AppDbContext>, IConfigurationRepository
    {
        private readonly AppDbContext context;

        public ConfigurationRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> IsExist(Configuration configuration)
        {
            return await context.Configurations.AnyAsync(a => a.Name == configuration.Name && a.Type == configuration.Type);
        }
    }
}

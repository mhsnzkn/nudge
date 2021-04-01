using DataAccess.Abstract;
using DataAccess.Base;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class ConfigurationRepository : RepositoryBase<Configuration, AppDbContext>, IConfigurationRepository
    {
        public ConfigurationRepository(AppDbContext context) : base(context)
        {

        }
    }
}

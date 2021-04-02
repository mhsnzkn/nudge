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
    public class ConfigurationLogic : IConfigurationLogic
    {
        private readonly IUnitOfWork uow;

        public ConfigurationLogic(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Add(Configuration Configuration)
        {
            uow.Configuration.Add(Configuration);
        }

        public void Delete(Configuration Configuration)
        {
            uow.Configuration.Delete(Configuration);
        }

        public async Task<Configuration> GetByIdAsync(int id)
        {
            return await uow.Configuration.GetByIdAsync(id);
        }

        public async Task<List<Configuration>> GetListAsync(Expression<Func<Configuration, bool>> filter = null)
        {
            return await uow.Configuration.Get(filter).ToListAsync();
        }

        public void Update(Configuration Configuration)
        {
            uow.Configuration.Update(Configuration);
        }
    }
}

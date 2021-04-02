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
    public class ConfigurationBusiness : IConfigurationBusiness
    {
        private readonly IUnitOfWork uow;

        public ConfigurationBusiness(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<ResultModel> Add(Configuration configuration)
        {
            var result = new ResultModel();
            try
            {
                if (await uow.Configuration.IsExist(configuration))
                {
                    result.SetError("The Configuration Already Exists");
                    return result;
                }
                uow.Configuration.Add(configuration);
                await uow.SaveAsync();
            }
            catch (Exception ex)
            {
                result.SetError(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel> Delete(Configuration Configuration)
        {
            uow.Configuration.Delete(Configuration);
            await uow.SaveAsync();
            return new ResultModel();
        }

        public async Task<Configuration> GetByIdAsync(int id)
        {
            return await uow.Configuration.GetByIdAsync(id);
        }

        public async Task<List<Configuration>> GetListAsync(Expression<Func<Configuration, bool>> filter = null)
        {
            return await uow.Configuration.Get(filter).ToListAsync();
        }

        public async Task<ResultModel> Update(Configuration Configuration)
        {
            uow.Configuration.Update(Configuration);
            await uow.SaveAsync();
            return new ResultModel();
        }
    }
}

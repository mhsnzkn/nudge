using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public interface IUnitOfWork
    {
        IBrandRepository Brand { get; }
        ICartRepository Cart { get; }
        IConfigurationRepository Configuration { get; }

        Task SaveAsync();
    }
}

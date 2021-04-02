using DataAccess.Base;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBrandRepository : IRepositoryBase<Brand>
    {
        Task<bool> IsExist(Brand brand);
    }
}

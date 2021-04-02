using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {

        private readonly ILogger<BrandController> _logger;
        private readonly IBrandLogic brandLogic;

        public BrandController(ILogger<BrandController> logger,
            IBrandLogic brandLogic)
        {
            _logger = logger;
            this.brandLogic = brandLogic;
        }

        [HttpGet]
        public async Task<IEnumerable<Brand>> Get()
        {
            var rng = new Random();
            return await brandLogic.GetListAsync();
        }
    }
}

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
        private readonly IBrandBusiness brandBusiness;

        public BrandController(ILogger<BrandController> logger,
            IBrandBusiness brandBusiness)
        {
            _logger = logger;
            this.brandBusiness = brandBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<Brand>> Get()
        {
            return await brandBusiness.GetListAsync();
        }

        // POST api/<BrandController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Brand model)
        {
            var result = await brandBusiness.Add(model);
            if (result.Error)
                return Ok(result);
            return CreatedAtAction(nameof(Get), new { model.Id });
        }
    }
}

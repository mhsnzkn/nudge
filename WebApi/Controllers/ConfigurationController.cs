using Business.Abstract;
using DataAccess.Base;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationBusiness configurationBusiness;

        public ConfigurationController(IConfigurationBusiness configurationBusiness)
        {
            this.configurationBusiness = configurationBusiness;
        }
        // GET: api/<ConfigurationController>
        [HttpGet]
        public async Task<IEnumerable<Configuration>> Get()
        {
            return await configurationBusiness.GetListAsync();
        }

        // GET api/<ConfigurationController>/5
        [HttpGet("{id}")]
        public async Task<Configuration> Get(int id)
        {
            return await configurationBusiness.GetByIdAsync(id);
        }

        // POST api/<ConfigurationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Configuration model)
        {
            var result = await configurationBusiness.Add(model);
            if (result.Error)
                return Ok(result);
            result.Data = model.Id;
            return CreatedAtAction(nameof(Get), result);
        }

    }
}

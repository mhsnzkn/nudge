using DataAccess.Base;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Utility;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IUnitOfWork repos;

        public ConfigurationController(IUnitOfWork repos)
        {
            this.repos = repos;
        }
        // GET: api/<ConfigurationController>
        [HttpGet]
        public async Task<IEnumerable<Configuration>> Get()
        {
            return await repos.Configuration.Get().ToListAsync();
        }

        // GET api/<ConfigurationController>/5
        [HttpGet("{id}")]
        public async Task<Configuration> Get(int id)
        {
            return await repos.Configuration.GetByIdAsync(id);
        }

        // POST api/<ConfigurationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Configuration model)
        {
            // Business

            return CreatedAtAction(nameof(Get), new { model.Id });
        }

        // PUT api/<ConfigurationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConfigurationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

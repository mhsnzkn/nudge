using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBusiness cartBusiness;

        public CartController(ICartBusiness cartBusiness)
        {
            this.cartBusiness = cartBusiness;
        }
        // GET: api/<CartController>
        [HttpGet]
        public async Task<IEnumerable<Cart>> Get()
        {
            return await cartBusiness.GetListAsync();
        }

        // POST api/<CartController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cart model)
        {
            model.UserId = HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await cartBusiness.Add(model);
            if (result.Error)
                return Ok(result);
            result.Data = model;
            return CreatedAtAction(nameof(Get), result);
        }
    }
}

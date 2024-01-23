using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDatabase.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UserDatabase.Api.Controllers;

namespace UserDatabase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EcommerceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("addresses")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var data = await _context.Address.ToListAsync();
            return Ok(data);
        }
    }

}

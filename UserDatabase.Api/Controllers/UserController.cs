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
    public class UserController : ControllerBase
    {
        private readonly ApplicaionDbContext _context;

        public UserController(ApplicaionDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult GetAll()
        {
            var datas = _context.Users.ToList();

            return Ok(datas);

        }
    }
}

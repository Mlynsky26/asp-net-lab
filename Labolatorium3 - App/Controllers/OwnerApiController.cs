using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OwnerApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetOwnerByName(string? q)
        {
            return Ok(
                q == null 
                ? 
                _context.Owners.Select(o => new { name = $"{o.Name} {o.Surname}", id = o.Id }).ToList() 
                :
                _context.Owners
                .Where(o => o.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new {name = $"{o.Name} {o.Surname}", id = o.Id})
                .ToList()
                );
        }
        [Route("{id}")]
        public IActionResult GetById(int id) {
            var organizations = _context.Owners.Find(id);
            if(organizations == null)
            {
                return NotFound();
            }else
            {
                return Ok(organizations);
            }
        }
    }
}

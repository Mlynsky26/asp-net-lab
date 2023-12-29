using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App.Controllers
{
    [Route("api/makers")]
    [ApiController]
    public class MakerApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MakerApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetMakersByName(string? q)
        {
            return Ok(
                q == null 
                ? 
                _context.Makers.Select(o => new { name = o.Name, id = o.Id }).ToList() 
                :
                _context.Makers
                .Where(o => o.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new {name = o.Name, id = o.Id})
                .ToList()
                );
        }
    }
}

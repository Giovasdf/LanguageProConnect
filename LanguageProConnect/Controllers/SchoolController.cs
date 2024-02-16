using LanguageProConnect.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LanguageProConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : Controller
    {
        private readonly VendorsDbContext dbContext;
        public SchoolController(VendorsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSchool()
        {
            return Ok(await dbContext.Schools.ToListAsync());
        }
    }
}

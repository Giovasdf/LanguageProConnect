using LanguageProConnect.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LanguageProConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageSpokenController : Controller
    {
        private readonly VendorsDbContext dbContext;
        public LanguageSpokenController(VendorsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLanguageSpoken()
        {
            return Ok(await dbContext.LanguageSpokens.ToListAsync());
        }

    }
}

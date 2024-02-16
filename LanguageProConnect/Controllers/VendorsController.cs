using LanguageProConnect.Data;
using Microsoft.AspNetCore.Mvc;

namespace LanguageProConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : Controller
    {
        private readonly VendorsDbContext dbContext;
        public VendorsController(VendorsDbContext dbContext) { 
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllVendors()
        {
            return Ok(dbContext.Vendors.ToList());
        }
    }
}

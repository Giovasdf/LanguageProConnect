using Microsoft.AspNetCore.Mvc;

namespace LanguageProConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

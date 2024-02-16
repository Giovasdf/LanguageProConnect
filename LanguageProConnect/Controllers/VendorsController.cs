using LanguageProConnect.Data;
using LanguageProConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllVendors()
        {
            return Ok(await dbContext.Vendors.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddVendor(AddVendorRequest addVendorRequest)
        {
            var vendor = new Vendor()
            {
                Id = Guid.NewGuid(),
                Name = addVendorRequest.Name,
                Description = addVendorRequest.Description,
                CountryOfVendor = addVendorRequest.CountryOfVendor,
                Email = addVendorRequest.Email,
                Phone = addVendorRequest.Phone,
                Password = addVendorRequest.Password
            };

            // Buscar o agregar el idioma hablado
            var languagesSpoken = await dbContext.LanguageSpokens.FindAsync(addVendorRequest.LanguagesSpoken.Id);
            if (languagesSpoken == null)
            {
                languagesSpoken = new LanguageSpoken
                {
                    Id = Guid.NewGuid(), // Nuevo Id
                    Name = addVendorRequest.LanguagesSpoken.Name
                };
                dbContext.LanguageSpokens.Add(languagesSpoken);
            }
            vendor.LanguagesSpoken = languagesSpoken;

            // Buscar o agregar la escuela
            var school = await dbContext.Schools.FindAsync(addVendorRequest.School.Id);
            if (school == null)
            {
                school = new School
                {
                    Id = Guid.NewGuid(), // Nuevo Id
                    Name = addVendorRequest.School.Name,
                    Country = addVendorRequest.School.Country,
                    City = addVendorRequest.School.City
                };
                dbContext.Schools.Add(school);
            }
            vendor.School = school;

            await dbContext.Vendors.AddAsync(vendor);
            await dbContext.SaveChangesAsync();
            return Ok(vendor);
        }

    }
}

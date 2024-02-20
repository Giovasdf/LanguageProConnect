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
        public VendorsController(VendorsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVendors()
        {
            // Selecciona todas las propiedades excepto Password
            var vendors = await dbContext.Vendors
                .Select(vendor => new
                {
                    vendor.Id,
                    vendor.Name,
                    vendor.Description,
                    vendor.CountryOfVendor,
                    vendor.Email,
                    vendor.Phone,
                    vendor.LanguagesSpokenId,
                    vendor.SchoolId,
                    vendor.LanguagesSpoken,
                    vendor.School
                })
                .ToListAsync();

            return Ok(vendors);
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

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateVendor([FromRoute] Guid id, UpdateVendorRequest updateVendorRequest)
        {
            var existingVendor = await dbContext.Vendors.FindAsync(id);

            if (existingVendor == null)
            {
                return NotFound();
            }

            existingVendor.Name = updateVendorRequest.Name;
            existingVendor.Description = updateVendorRequest.Description;
            existingVendor.CountryOfVendor = updateVendorRequest.CountryOfVendor;
            existingVendor.Email = updateVendorRequest.Email;
            existingVendor.Phone = updateVendorRequest.Phone;
            //existingVendor.Password = updateVendorRequest.Password;

            var languagesSpoken = await dbContext.LanguageSpokens.FindAsync(updateVendorRequest.LanguagesSpoken.Id);
            if (languagesSpoken == null)
            {
                languagesSpoken = new LanguageSpoken
                {
                    Id = updateVendorRequest.LanguagesSpoken.Id,
                    Name = updateVendorRequest.LanguagesSpoken.Name
                };
                dbContext.LanguageSpokens.Add(languagesSpoken);
            }
            existingVendor.LanguagesSpoken = languagesSpoken;

            var school = await dbContext.Schools.FindAsync(updateVendorRequest.School.Id);
            if (school == null)
            {
                school = new School
                {
                    Id = updateVendorRequest.School.Id,
                    Name = updateVendorRequest.School.Name,
                    Country = updateVendorRequest.School.Country,
                    City = updateVendorRequest.School.City
                };
                dbContext.Schools.Add(school);
            }
            existingVendor.School = school;

            await dbContext.SaveChangesAsync();

            return Ok(existingVendor);
        }




        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteVendor([FromRoute] Guid id)
        {
            // Buscar el proveedor en la base de datos
            var existingVendor = await dbContext.Vendors.FindAsync(id);

            if (existingVendor == null)
            {
                return NotFound(); // El proveedor no existe
            }

            // Eliminar el proveedor de la base de datos
            dbContext.Vendors.Remove(existingVendor);
            await dbContext.SaveChangesAsync();

            return NoContent(); // Devolver una respuesta exitosa sin contenido
        }


    }
}
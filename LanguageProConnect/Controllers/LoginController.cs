using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LanguageProConnect.Models;
using LanguageProConnect.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail; // Importa los modelos de tu aplicación

namespace LanguageProConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly VendorsDbContext dbContext; // Contexto de la base de datos

        public LoginController(VendorsDbContext context)
        {
            dbContext = context;
        }

        // Método para iniciar sesión
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var vendor = await dbContext.Vendors.FirstOrDefaultAsync(v => v.Email == loginRequest.Email && v.Password == loginRequest.Password);

            if (vendor == null)
            {
                return NotFound("Invalid email or password"); 
            }

            return Ok(true); 
        }

        //[HttpPost]
        //public async Task<IActionResult> RecoverAccount(string email)
        //{

        //    var message = new MailMessage();
        //    message.To.Add(new MailAddress(email));
        //    message.Subject = "Recuperación de cuenta";
        //    message.Body = "Por favor, haga clic en el enlace para recuperar su cuenta.";

        //    using (var smtp = new SmtpClient())
        //    {
        //        await smtp.SendMailAsync(message);
        //    }

        //    // Retornar un mensaje indicando que se ha enviado el correo electrónico
        //    return Content("Se ha enviado un correo electrónico con instrucciones para recuperar su cuenta.");
        //}
    }
}

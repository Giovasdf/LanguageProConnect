using System.ComponentModel.DataAnnotations;

namespace LanguageProConnect.Models
{
    public class Vendor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryOfVendor { get; set; }
        public string[] LanguagesSpoken { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }
        public School School { get; set; }
    }
}

namespace LanguageProConnect.Models
{
    public class AddVendorRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryOfVendor { get; set; }
        public LanguageSpoken LanguagesSpoken { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }
        public School School { get; set; }
    }
}

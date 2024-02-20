namespace LanguageProConnect.Models
{
    public class UpdateVendorRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryOfVendor { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }

        public Guid? LanguagesSpokenId { get; set; }
        public LanguageSpoken LanguagesSpoken { get; set; }

        public Guid? SchoolId { get; set; }
        public School School { get; set; }
    }
}

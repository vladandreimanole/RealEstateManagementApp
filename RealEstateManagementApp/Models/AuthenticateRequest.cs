using System.ComponentModel.DataAnnotations;

namespace RealEstateManagementApp.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}

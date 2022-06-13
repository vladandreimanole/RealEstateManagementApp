namespace RealEstateManagementApp.Authentification;

    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
        public int? userId { get; set; }
    }


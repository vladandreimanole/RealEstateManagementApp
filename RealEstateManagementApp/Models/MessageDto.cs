namespace RealEstateManagementApp.Models
{
    public class MessageDto
    {
        public string? msgText { get; set; }
        public string? chatId { get; set; }
        public int? tenantId { get; set; }
        public int? landlordId { get; set; }
        public DateTime? sentTime { get; set; }
        public int? sentByUserId { get; set; }
    }
}

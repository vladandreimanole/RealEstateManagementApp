using System.ComponentModel.DataAnnotations.Schema;

namespace DataManager.Models
{
    [Table("Properties", Schema = "dbo")]
    public partial class Property
    {
        public Property()
        {
            UploadedImages = new HashSet<UploadedImage>();
        }

        public int PropertyId { get; set; }
        public string? PropertyName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public long? Value { get; set; }
        public int? TenantId { get; set; }
        public int? LandlordId { get; set; }
        [NotMapped]
        public virtual Landlord? Landlord { get; set; }
        [NotMapped]
        public virtual Contract? PropertyNavigation { get; set; } = null!;
        [NotMapped]
        public virtual Tenant? Tenant { get; set; }
        [NotMapped]
        public virtual ICollection<UploadedImage>? UploadedImages { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class Property
    {
        public Property()
        {
            PropertyVisualizations = new HashSet<PropertyVisualization>();
            UploadedImages = new HashSet<UploadedImage>();
        }

        public int PropertyId { get; set; }
        public string? PropertyName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public long? Value { get; set; }
        public int? UserId { get; set; }
        public bool? Unlisted { get; set; }

        public virtual User? User { get; set; }
        public virtual Contract? Contract { get; set; }
        public virtual ICollection<PropertyVisualization> PropertyVisualizations { get; set; }
        public virtual ICollection<UploadedImage> UploadedImages { get; set; }
    }
}

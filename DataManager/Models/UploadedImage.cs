using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class UploadedImage
    {
        public int ImageId { get; set; }
        public byte[] ImageData { get; set; } = null!;
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; } = null!;
    }
}

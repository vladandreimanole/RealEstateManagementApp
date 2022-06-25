using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class PropertyVisualization
    {
        public int Id { get; set; }
        public int? PropertyId { get; set; }
        public int? Views { get; set; }
        public DateTime? Date { get; set; }

        public virtual Property? Property { get; set; }
    }
}

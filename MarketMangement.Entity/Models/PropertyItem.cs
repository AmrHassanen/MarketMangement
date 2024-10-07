using System;

namespace MarketMangement.Entity.Models
{
    public class PropertyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Each property item belongs to only one Device
        public int DeviceId { get; set; } // Foreign key to Device
        public Device Device { get; set; } // Navigation property
    }
}

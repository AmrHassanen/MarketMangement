using System;
using System.Collections.Generic;

namespace MarketMangement.Entity.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string DeviceName { get; set; }
        public int DeviceCategoryId { get; set; }
        public DeviceCategory DeviceCategory { get; set; }

        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }

        // A device can have many PropertyItems
        public ICollection<PropertyItem> PropertyItems { get; set; } = new List<PropertyItem>();
    }
}

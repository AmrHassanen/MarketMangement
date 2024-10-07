using MarketMangement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMangement.Service.DTOs
{
    public class DeviceDto
    {
        public int ID { get; set; }
        public string DeviceName { get; set; }
        public int DeviceCategoryId { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }

        // Include PropertyItems in the DeviceDto
        public ICollection<PropertyItemDto> ?PropertyItems { get; set; }
    }
}

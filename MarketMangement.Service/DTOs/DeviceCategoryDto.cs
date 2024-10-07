using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMangement.Service.DTOs
{
    public class DeviceCategoryDto
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int PropertyId { get; set; }  // Foreign key for Property
    }
}

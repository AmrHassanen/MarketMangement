using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMangement.Entity.Models
{
    public class DeviceCategory
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }  

        public int PropertyId { get; set; }  
        public Property Property { get; set; }  
    }

}

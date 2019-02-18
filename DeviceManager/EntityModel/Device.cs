using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.EntityModel
{
    public class Device
    {
        public Device()
        {
            CreatedDateTime = DateTime.Now;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Decimal PriceDevice { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceType DeviceType { get; set; }

        public ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.EntityModel
{
    public class DeviceTypeProperty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DeviceTypeId { get; set; } 

        public DeviceType DeviceType { get; set; }

        public ICollection<DevicePropertyValue> DevicePropertyValues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.EntityModel
{
    public class DevicePropertyValue
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }

        public int DeviceTypePropertyId { get; set; }

        public DeviceTypeProperty DeviceTypeProperty { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.EntityModel
{
    public class DeviceType
    {
        public DeviceType()
        {
             SubDeviceTypes = new HashSet<DeviceType>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public virtual DeviceType Parent { get; set; }

        public virtual ICollection<DeviceType> SubDeviceTypes { get; set; }

        public  ICollection<DeviceTypeProperty> DeviceTypeProperties { get; set; }
    }
}

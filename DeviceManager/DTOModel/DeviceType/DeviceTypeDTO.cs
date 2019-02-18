using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.DTOModel.DeviceType
{
    public class DeviceTypeDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public DeviceTypeDTO Parent { get; set; }

        public ICollection<DeviceTypeDTO> SubDeviceTypes { get; set; }

        public ICollection<DeviceTypePropertyWithoutValuesDTO> DeviceTypeProperties { get; set; }
    }
}

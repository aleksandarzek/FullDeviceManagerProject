using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.DTOModel.DeviceType
{
    public class CreateOrUpdateDeviceTypeDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public ICollection<DeviceTypePropertyDTO> DeviceTypeProperties { get; set; }
    }
}

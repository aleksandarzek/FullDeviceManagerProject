using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.DTOModel.DeviceType;

namespace DeviceManager.DTOModel.Device
{
    public class CreateOrUpdateDeviceDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? DeviceTypeId { get; set; }

        public decimal Price { get; set; }

        public ICollection<CreateOrUpdateDevicePropertyValueDTO> DevicePropertyValues { get; set; }
        
        
    }
}

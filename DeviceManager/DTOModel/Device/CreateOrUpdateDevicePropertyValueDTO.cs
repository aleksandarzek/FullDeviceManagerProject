using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.DTOModel.DeviceType;

namespace DeviceManager.DTOModel.Device
{
    public class CreateOrUpdateDevicePropertyValueDTO
    {
        public int? Id { get; set; }

        public int? DeviceId { get; set; }

        public int? DeviceTypePropertyId { get; set; }
        
        public string Value { get; set; }
        
        
    }
}

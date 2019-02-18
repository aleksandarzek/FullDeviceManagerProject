using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.DTOModel.DeviceType
{
    public class DeviceTypePropertyWithoutValuesDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int DeviceTypeId { get; set; }
        
    }
}

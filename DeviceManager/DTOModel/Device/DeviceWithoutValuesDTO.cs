using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.DTOModel.DeviceType;

namespace DeviceManager.DTOModel.Device
{
    public class DeviceWithoutValuesDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceTypeWithoutValuesDTO DeviceType { get; set; }

    }
}

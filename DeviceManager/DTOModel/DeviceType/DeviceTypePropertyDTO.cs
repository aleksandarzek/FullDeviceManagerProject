﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.DTOModel.DeviceType
{
    public class DeviceTypePropertyDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? DeviceTypeId { get; set; }
        
        public ICollection<DevicePropertyValueDTO> DevicePropertyValues { get; set; }
    }
}

using AutoMapper;
using DeviceManager.DTOModel;
using DeviceManager.DTOModel.Device;
using DeviceManager.DTOModel.DeviceType;
using DeviceManager.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrUpdateDeviceDTO, Device>();

            CreateMap<DeviceTypeDTO, DeviceType>();

            CreateMap<CreateOrUpdateDeviceTypeDTO, DeviceType>();

            CreateMap<Device, DeviceWithoutValuesDTO>();

            CreateMap<DeviceTypeProperty, DeviceTypePropertyWithoutValuesDTO>();

            CreateMap<CreateOrUpdateDeviceDTO, Device>();

            CreateMap<CreateOrUpdateDevicePropertyValueDTO, DevicePropertyValue>();

            CreateMap<DeviceTypePropertyDTO, DeviceTypeProperty>();

            CreateMap<DevicePropertyValueDTO, DevicePropertyValue>();
        }
    }
}

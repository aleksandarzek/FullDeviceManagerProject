using DeviceManager.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Repository
{
    public interface IDeviceTypeRepository
    {
        /// <summary>Get all types of devices.
        /// </summary>
        Task<IEnumerable<DeviceType>> GetDeviceType();
        
        /// <summary>Get device type by Id.
        /// </summary>
        Task<DeviceType> GetDeviceTypeById(int id);

        /// <summary>Create device type.
        /// </summary>
        Task<DeviceType> CreateDeviceType(DeviceType deviceType);

        /// <summary>Update device type.
        /// </summary>
        Task<DeviceType> UpdateDeviceType(DeviceType deviceType);

        /// <summary>Delete device type.
        /// </summary>
        Task<int> DeleteDeviceType(int id);

        /// <summary>Check if the device exists.
        /// </summary>
        Task<bool> Exist(int id);
    }
}

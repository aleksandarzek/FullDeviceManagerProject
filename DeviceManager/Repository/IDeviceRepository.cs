using DeviceManager.EntityModel;
using DeviceManager.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Repository
{
    public interface IDeviceRepository
    {
        /// <summary>Get all devices.
        /// </summary>
        Task<IEnumerable<Device>> GetDevices();

        /// <summary>Get devices with criterion.
        /// </summary>
        Task<IEnumerable<Device>> GetDeviceWithCriterion(DeviceSearchCriterion deviceSearchCriterion);

        /// <summary>Get device by Id.
        /// </summary>
        Task<Device> GetDeviceById(int id);

        /// <summary>Create device.
        /// </summary>
        Task<Device> CreateDevice(Device device);

        /// <summary>Update device.
        /// </summary>
        Task<Device> UpdateDevice(Device device);

        /// <summary>Delete device.
        /// </summary>
        Task<int> DeleteDevice(int id);

        /// <summary> Check if the device exists.
        /// </summary>
        Task<bool> Exist(int id);
    }
}

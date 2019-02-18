using DeviceManager.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.DBContext;
using Microsoft.EntityFrameworkCore;
using DeviceManager.Utility;

namespace DeviceManager.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DeviceManagerDbContext _context;

        public DeviceRepository(DeviceManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Device> CreateDevice(Device device)
        {
            await _context.AddAsync(device);
            if (device.DevicePropertyValues != null)
            {
                foreach (var a in device.DevicePropertyValues)
                {
                    await _context.AddAsync(a);
                }
            }
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<int> DeleteDevice(int id)
        {
            _context.Devices.Remove(await GetDeviceById(id));

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<Device> GetDeviceById(int id)
        {
            return await _context.Devices
                .Include(a => a.DevicePropertyValues)
                .ThenInclude(devicePropValue => devicePropValue.DeviceTypeProperty)
                .ThenInclude(deviceTypeProp => deviceTypeProp.DeviceType)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Device>> GetDevices()
        {
            return await _context.Devices
            .Include(p => p.DeviceType).ThenInclude(p => p.DeviceTypeProperties)
            .Include(p => p.DevicePropertyValues)
            .ToListAsync();
        }

        public async Task<IEnumerable<Device>> GetDeviceWithCriterion(DeviceSearchCriterion deviceSearchCriterion)
        {
            return await _context.Devices
            .Include(a => a.DeviceType)
            .ThenInclude(devicetype => devicetype.DeviceTypeProperties)
                .Where(p => p.Name.Contains(deviceSearchCriterion.Name) 
                    && p.DeviceType.Name.Contains(deviceSearchCriterion.TypeDevice) 
                    && p.DevicePropertyValues.Any(devPropVal=>devPropVal.Value.Contains(deviceSearchCriterion.DeviceValues)
                    && p.CreatedDateTime >= deviceSearchCriterion.DateTimeGreatOrEqThan
                    && p.CreatedDateTime >  deviceSearchCriterion.DateTimeGreatThan
                    && p.CreatedDateTime <  deviceSearchCriterion.DateTimeLessThan
                    && p.CreatedDateTime <= deviceSearchCriterion.DateTimeLessOrEqThan
                    && p.PriceDevice >= deviceSearchCriterion.PriceGreatOrEqThan 
                    && p.PriceDevice > deviceSearchCriterion.PriceGreatThan
                    && p.PriceDevice < deviceSearchCriterion.PriceLessThan
                    && p.PriceDevice <= deviceSearchCriterion.PriceLessOrEqThan))
            .Skip(deviceSearchCriterion.DeviceNumOnThisPage * (deviceSearchCriterion.PageNumRes - 1))
            .Take(deviceSearchCriterion.DeviceNumOnThisPage)
            .ToListAsync();
        }

        public async Task<Device> UpdateDevice(Device device)
        {
            _context.Update(device);
            if (device.DevicePropertyValues != null)
            {
                foreach (var a in device.DevicePropertyValues)
                {
                    if(a.Id > 0)
                    {
                        _context.Update(a);
                    }
                    else
                    {
                        await _context.AddAsync(a);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> Exist(int id)
        {
            var exist = await _context.Devices.FindAsync(id);
            if(exist != null)
            {
                return true;
            }
            return false;
        }
    }
}

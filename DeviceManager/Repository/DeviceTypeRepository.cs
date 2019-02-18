using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.DBContext;
using DeviceManager.EntityModel;
using DeviceManager.Utility;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Repository
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        private readonly DeviceManagerDbContext _context;

        public DeviceTypeRepository(DeviceManagerDbContext context)
        {
            _context = context;
        }

        public async Task<DeviceType> CreateDeviceType(DeviceType deviceType)
        {
            
            await _context.AddAsync(deviceType);
            if (deviceType.DeviceTypeProperties != null)
            {
                foreach (var a in deviceType.DeviceTypeProperties)
                {
                    await _context.AddAsync(a);
                }
            }
            
            await _context.SaveChangesAsync();
            return deviceType;
        }
        
        public async Task<DeviceType> UpdateDeviceType(DeviceType deviceType)
        {
            _context.Update(deviceType);
            if (deviceType.DeviceTypeProperties != null)
            {
                foreach (var a in deviceType.DeviceTypeProperties)
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
            return deviceType;
        }
        

        public async Task<int> DeleteDeviceType(int id)
        {
            _context.DeviceTypes.Remove(await GetDeviceTypeById(id));

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<DeviceType>> GetDeviceType()
        {
            var devices =  await _context.DeviceTypes
            .Include(p => p.Parent).ThenInclude(p => p.DeviceTypeProperties)
            .Include(p => p.DeviceTypeProperties)
            .ToListAsync();

            return devices.Where(a=>a.Parent == null);
        }

        public async Task<DeviceType> GetDeviceTypeById(int id)
        {
            var devices =  await _context.DeviceTypes
            .Include(p => p.Parent).ThenInclude(p => p.DeviceTypeProperties)
            .Include(p => p.DeviceTypeProperties)
            .ToListAsync();

            return devices.FirstOrDefault(s => s.Id == id);   
        }

        public async Task<bool> Exist(int id)
        {
            var exist = await _context.DeviceTypes.FindAsync(id);
            if(exist != null)
            {
                return true;
            }
            return false;
        }

    }
}

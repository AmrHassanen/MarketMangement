using AutoMapper;
using MarketMangement.Entity.Models;
using MarketMangement.MVC.Data;
using MarketMangement.Service.DTOs;
using MarketMangement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.Service.Implementations
{

    public class DeviceService : IDeviceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeviceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeviceDto>> GetAllDevicesAsync()
        {
            var devices = await _context.Devices
                .Include(d => d.PropertyItems)
                .ToListAsync();

            return _mapper.Map<IEnumerable<DeviceDto>>(devices);
        }

        public async Task<DeviceDto> GetDeviceByIdAsync(int id)
        {
            var device = await _context.Devices
                .Include(d => d.PropertyItems)
                .FirstOrDefaultAsync(d => d.ID == id);

            return device == null ? null : _mapper.Map<DeviceDto>(device);
        }

        public async Task<DeviceDto> AddDeviceAsync(DeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();

            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<DeviceDto> UpdateDeviceAsync(int id, DeviceDto updatedDeviceDto)
        {
            var device = await _context.Devices
                .Include(d => d.PropertyItems)
                .FirstOrDefaultAsync(d => d.ID == id);

            if (device == null)
            {
                return null;
            }

            _mapper.Map(updatedDeviceDto, device);
            await _context.SaveChangesAsync();

            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<bool> DeleteDeviceAsync(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return false;
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<PropertyItemDto> AddPropertyItemAsync(PropertyItemDto propertyItemDto)
        {
            var propertyItem = _mapper.Map<PropertyItem>(propertyItemDto);
            await _context.PropertyItems.AddAsync(propertyItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<PropertyItemDto>(propertyItem);
        }

        public async Task<PropertyItemDto> GetPropertyItemByIdAsync(int id)
        {
            var propertyItem = await _context.PropertyItems.FindAsync(id);
            return _mapper.Map<PropertyItemDto>(propertyItem);
        }

        public async Task<PropertyItemDto> UpdatePropertyItemAsync(int id, PropertyItemDto propertyItemDto)
        {
            var propertyItem = await _context.PropertyItems.FindAsync(id);
            if (propertyItem == null)
            {
                return null;
            }

            _mapper.Map(propertyItemDto, propertyItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<PropertyItemDto>(propertyItem);
        }

        public async Task<bool> DeletePropertyItemAsync(int id)
        {
            var propertyItem = await _context.PropertyItems.FindAsync(id);
            if (propertyItem == null)
            {
                return false;
            }

            _context.PropertyItems.Remove(propertyItem);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

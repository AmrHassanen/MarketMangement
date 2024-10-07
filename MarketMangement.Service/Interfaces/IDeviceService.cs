using MarketMangement.Entity.Models;
using MarketMangement.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.Service.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDto>> GetAllDevicesAsync();
        Task<DeviceDto> GetDeviceByIdAsync(int id);
        Task<DeviceDto> AddDeviceAsync(DeviceDto deviceDto);
        Task<DeviceDto> UpdateDeviceAsync(int id, DeviceDto updatedDeviceDto);
        Task<bool> DeleteDeviceAsync(int id);
        Task<PropertyItemDto> AddPropertyItemAsync(PropertyItemDto propertyItemDto);
        Task<PropertyItemDto> GetPropertyItemByIdAsync(int id);
        Task<PropertyItemDto> UpdatePropertyItemAsync(int id, PropertyItemDto propertyItemDto);
        Task<bool> DeletePropertyItemAsync(int id);
    }
}

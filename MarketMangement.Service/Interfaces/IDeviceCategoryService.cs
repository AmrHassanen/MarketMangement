using MarketMangement.Entity.Models; // Ensure you're importing the DeviceCategory model
using MarketMangement.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.Service.Interfaces
{
    public interface IDeviceCategoryService
    {
        Task<DeviceCategoryDto> AddDeviceCategoryAsync(DeviceCategoryDto deviceCategory);
        Task<DeviceCategory> GetDeviceCategoryByIdAsync(int id);
        Task<DeviceCategoryDto> UpdateDeviceCategoryAsync(int id, DeviceCategoryDto updatedDeviceCategory);
        Task<IEnumerable<DeviceCategoryDto>> GetAllCategoriesAsync();
        Task<bool> DeleteDeviceCategoryAsync(int id);
        Task<IEnumerable<DeviceCategory>> GetAllDeviceCategoriesAsync(); // Returning DeviceCategory directly
    }
}

using AutoMapper;
using MarketMangement.Entity.Models;
using MarketMangement.MVC.Data;
using MarketMangement.MVC.DTOs;
using MarketMangement.Service.DTOs;
using MarketMangement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.Service.Implementations
{
    public class DeviceCategoryService : IDeviceCategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeviceCategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeviceCategoryDto>> GetAllCategoriesAsync()
        {
            return await _context.DeviceCategories
                .Select(c => new DeviceCategoryDto { ID = c.ID, CategoryName = c.CategoryName }) // Adjust based on your actual property names
                .ToListAsync();
        }


        // Add a new device category to the database
        public async Task<DeviceCategoryDto> AddDeviceCategoryAsync(DeviceCategoryDto deviceCategoryDto)
        {
            // Map the DTO to the entity
            var deviceCategory = _mapper.Map<DeviceCategory>(deviceCategoryDto);

            // Add to the database
            _context.DeviceCategories.Add(deviceCategory);
            await _context.SaveChangesAsync();

            // Return the newly created device category as a DTO
            return _mapper.Map<DeviceCategoryDto>(deviceCategory);
        }

        // Get a device category by its ID
        public async Task<DeviceCategory> GetDeviceCategoryByIdAsync(int id)
        {
            // Find the device category by ID
            var deviceCategory = await _context.DeviceCategories.FindAsync(id);
            return deviceCategory; // Return the entity directly
        }

        // Update an existing device category by ID
        public async Task<DeviceCategoryDto> UpdateDeviceCategoryAsync(int id, DeviceCategoryDto updatedDeviceCategoryDto)
        {
            // Find the existing device category
            var existingCategory = await _context.DeviceCategories.FindAsync(id);
            if (existingCategory == null)
            {
                return null; // Return null if the device category doesn't exist
            }

            // Map the updatedDeviceCategoryDto to the existing entity
            _mapper.Map(updatedDeviceCategoryDto, existingCategory);

            // Save the updated entity
            await _context.SaveChangesAsync();

            // Return the updated device category as a DTO
            return _mapper.Map<DeviceCategoryDto>(existingCategory);
        }

        // Delete a device category by its ID
        public async Task<bool> DeleteDeviceCategoryAsync(int id)
        {
            // Find the device category by ID
            var deviceCategory = await _context.DeviceCategories.FindAsync(id);
            if (deviceCategory == null)
            {
                return false; // Return false if the device category doesn't exist
            }

            // Remove the device category from the database
            _context.DeviceCategories.Remove(deviceCategory);
            await _context.SaveChangesAsync();

            return true; // Return true if successfully deleted
        }

        // Get all device categories in the database
        public async Task<IEnumerable<DeviceCategory>> GetAllDeviceCategoriesAsync()
        {
            // Retrieve all device categories
            var deviceCategories = await _context.DeviceCategories.ToListAsync();
            return deviceCategories; // Return the list of DeviceCategory entities
        }
    }
}

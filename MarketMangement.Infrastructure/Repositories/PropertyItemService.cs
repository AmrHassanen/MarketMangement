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
    public class PropertyItemService : IPropertyItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PropertyItemService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PropertyItemDto> AddPropertyItemAsync(PropertyItemDto propertyItemDto)
        {
            // Map DTO to Entity
            var propertyItem = _mapper.Map<PropertyItem>(propertyItemDto);

            // Add to the database
            await _context.PropertyItems.AddAsync(propertyItem);
            await _context.SaveChangesAsync();

            // Map back to DTO
            return _mapper.Map<PropertyItemDto>(propertyItem);
        }

        public async Task<PropertyItem> GetPropertyItemByIdAsync(int id)
        {
            // Return the PropertyItem entity by ID
            return await _context.PropertyItems.FindAsync(id);
        }

        public async Task<PropertyItemDto> UpdatePropertyItemAsync(int id, PropertyItemDto updatedPropertyItemDto)
        {
            // Find the existing property item
            var existingPropertyItem = await _context.PropertyItems.FindAsync(id);
            if (existingPropertyItem == null)
            {
                return null; // PropertyItem not found
            }

            // Map updated properties to the existing entity
            _mapper.Map(updatedPropertyItemDto, existingPropertyItem);

            // Save changes
            await _context.SaveChangesAsync();

            // Return updated DTO
            return _mapper.Map<PropertyItemDto>(existingPropertyItem);
        }

        public async Task<bool> DeletePropertyItemAsync(int id)
        {
            // Find the property item to delete
            var propertyItem = await _context.PropertyItems.FindAsync(id);
            if (propertyItem == null)
            {
                return false; // PropertyItem not found
            }

            // Remove the property item
            _context.PropertyItems.Remove(propertyItem);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PropertyItem>> GetAllPropertyItemsAsync()
        {
            // Return all PropertyItem entities
            return await _context.PropertyItems.ToListAsync();
        }
    }
}

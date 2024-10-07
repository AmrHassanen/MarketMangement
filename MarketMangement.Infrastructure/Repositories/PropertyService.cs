using AutoMapper;
using MarketMangement.Entity.Models;
using MarketMangement.MVC.Data;
using MarketMangement.MVC.DTOs;
using MarketMangement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketMangement.Service.Implementations
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PropertyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Add a new property to the database
        public async Task<PropertyDto> AddPropertyAsync(PropertyDto propertyDto)
        {
            // Map the DTO to the entity
            var property = _mapper.Map<Property>(propertyDto);

            // Add to the database and save changes
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            // Return the newly created property as a DTO
            return _mapper.Map<PropertyDto>(property);
        }

        // Get a property by its ID
        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            // Find the property by ID
            var property = await _context.Properties
                                         .Include(p => p.DeviceCategory)
                                         .FirstOrDefaultAsync(p => p.ID == id);

            return property;
        }

        // Update an existing property by ID
        public async Task<PropertyDto> UpdatePropertyAsync(int id, PropertyDto updatedPropertyDto)
        {
            // Find the existing property
            var existingProperty = await _context.Properties.FindAsync(id);

            if (existingProperty == null)
            {
                return null; // Return null if the property doesn't exist
            }

            // Map the updatedPropertyDto to the existing property entity
            _mapper.Map(updatedPropertyDto, existingProperty);

            // Save the updated entity
            await _context.SaveChangesAsync();

            // Return the updated property as a DTO
            return _mapper.Map<PropertyDto>(existingProperty);
        }

        // Delete a property by its ID
        public async Task<bool> DeletePropertyAsync(int id)
        {
            // Find the property by ID
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return false; // Return false if the property doesn't exist
            }

            // Remove the property from the database
            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return true;
        }

        // Get all properties in the database
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            // Retrieve all properties with their device categories
            var properties = await _context.Properties
                                           .Include(p => p.DeviceCategory)
                                           .ToListAsync();
            return properties;
        }
    }
}

using MarketMangement.Entity.Models;
using MarketMangement.MVC.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.Service.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDto> AddPropertyAsync(PropertyDto property);
        Task<Property> GetPropertyByIdAsync(int id);
        Task<PropertyDto> UpdatePropertyAsync(int id, PropertyDto updatedProperty);
        Task<bool> DeletePropertyAsync(int id);
        Task<IEnumerable<Property>> GetAllPropertiesAsync();
    }
}

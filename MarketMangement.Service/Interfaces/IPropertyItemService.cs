using MarketMangement.Entity.Models;
using MarketMangement.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.Service.Interfaces
{
    public interface IPropertyItemService
    {
        Task<PropertyItemDto> AddPropertyItemAsync(PropertyItemDto propertyItemDto);
        Task<PropertyItem> GetPropertyItemByIdAsync(int id); // Return PropertyItem entity
        Task<PropertyItemDto> UpdatePropertyItemAsync(int id, PropertyItemDto updatedPropertyItemDto);
        Task<bool> DeletePropertyItemAsync(int id);
        Task<IEnumerable<PropertyItem>> GetAllPropertyItemsAsync(); // Return IEnumerable<PropertyItem>
    }
}

using MarketMangement.Entity.Models;
using MarketMangement.Service.DTOs;
using MarketMangement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.MVC.Controllers
{
    public class PropertyItemController : Controller
    {
        private readonly IPropertyItemService _propertyItemService;

        public PropertyItemController(IPropertyItemService propertyItemService)
        {
            _propertyItemService = propertyItemService;
        }

        // GET: PropertyItem
        public async Task<IActionResult> Index()
        {
            var propertyItems = await _propertyItemService.GetAllPropertyItemsAsync();
            return View(propertyItems); // Passes a list of PropertyItems to the view
        }

        // GET: PropertyItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyItemDto propertyItemDto)
        {
            if (ModelState.IsValid)
            {
                await _propertyItemService.AddPropertyItemAsync(propertyItemDto);
                return RedirectToAction(nameof(Index));
            }
            return View(propertyItemDto); // Return view with errors if model state is invalid
        }

        // GET: PropertyItem/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var propertyItem = await _propertyItemService.GetPropertyItemByIdAsync(id);
            if (propertyItem == null)
            {
                return NotFound();
            }

            var propertyItemDto = new PropertyItemDto
            {
                Id = propertyItem.Id,
                Name = propertyItem.Name
            };

            return View(propertyItemDto);
        }

        // POST: PropertyItem/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PropertyItemDto updatedPropertyItemDto)
        {
            if (ModelState.IsValid)
            {
                var updatedPropertyItem = await _propertyItemService.UpdatePropertyItemAsync(id, updatedPropertyItemDto);
                if (updatedPropertyItem == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updatedPropertyItemDto); // Return view with errors if model state is invalid
        }

        // GET: PropertyItem/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var propertyItem = await _propertyItemService.GetPropertyItemByIdAsync(id);
            if (propertyItem == null)
            {
                return NotFound();
            }
            return View(propertyItem);
        }

        // POST: PropertyItem/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _propertyItemService.DeletePropertyItemAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

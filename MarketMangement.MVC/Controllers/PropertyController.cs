using MarketMangement.MVC.DTOs;
using MarketMangement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.MVC.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // GET: Property
        public async Task<IActionResult> Index()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return View(properties); // Pass the list of properties to the view
        }

        // GET: Property/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property); // Pass the property to the details view
        }

        // GET: Property/Create
        public IActionResult Create()
        {
            return View(); // Return the create view
        }

        // POST: Property/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyDto propertyDto)
        {
            if (ModelState.IsValid)
            {
                await _propertyService.AddPropertyAsync(propertyDto);
                return RedirectToAction(nameof(Index)); // Redirect to the index action after creation
            }
            return View(propertyDto); // Return the view with errors if model state is invalid
        }

        // GET: Property/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property); // Pass the property to the edit view
        }

        // POST: Property/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PropertyDto propertyDto)
        {
            if (id != propertyDto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedProperty = await _propertyService.UpdatePropertyAsync(id, propertyDto);
                if (updatedProperty == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index)); // Redirect to index after update
            }
            return View(propertyDto); // Return the view with errors if model state is invalid
        }

        // GET: Property/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property); // Pass the property to the delete view
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _propertyService.DeletePropertyAsync(id);
            if (!result)
            {
                return NotFound(); // Handle case where property is not found
            }
            return RedirectToAction(nameof(Index)); // Redirect to index after deletion
        }
    }
}

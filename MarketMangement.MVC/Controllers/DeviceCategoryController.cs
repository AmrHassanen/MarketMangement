using MarketMangement.MVC.DTOs;
using MarketMangement.Service.DTOs;
using MarketMangement.Service.Implementations;
using MarketMangement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketMangement.MVC.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly IDeviceCategoryService _deviceCategoryService;
        private readonly IPropertyService _propertyService;

        public DeviceCategoryController(IDeviceCategoryService deviceCategoryService, IPropertyService propertyService)
        {
            _deviceCategoryService = deviceCategoryService;
            _propertyService = propertyService;
        }

        // GET: DeviceCategory
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var deviceCategories = await _deviceCategoryService.GetAllDeviceCategoriesAsync();
            var properties = await _propertyService.GetAllPropertiesAsync(); // Assuming you have a service to get properties

            ViewBag.Properties = new SelectList(properties, "ID", "IP"); // Assuming Property has ID and Name properties

            return View(deviceCategories); // Explicit path to the view
        }

        // GET: DeviceCategory/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var deviceCategory = await _deviceCategoryService.GetDeviceCategoryByIdAsync(id);
            if (deviceCategory == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(deviceCategory);
        }

        // GET: DeviceCategory/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceCategoryDto deviceCategoryDto)
        {
            if (ModelState.IsValid)
            {
                await _deviceCategoryService.AddDeviceCategoryAsync(deviceCategoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View(deviceCategoryDto); // Return to the view with the model if invalid
        }

        // GET: DeviceCategory/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var deviceCategory = await _deviceCategoryService.GetDeviceCategoryByIdAsync(id);
            if (deviceCategory == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(deviceCategory);
        }

        // POST: DeviceCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeviceCategoryDto updatedDeviceCategory)
        {
            if (id != updatedDeviceCategory.ID)
            {
                return NotFound(); // Return 404 if IDs don't match
            }

            if (ModelState.IsValid)
            {
                await _deviceCategoryService.UpdateDeviceCategoryAsync(id, updatedDeviceCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedDeviceCategory); // Return to the view with the model if invalid
        }

        // GET: DeviceCategory/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deviceCategory = await _deviceCategoryService.GetDeviceCategoryByIdAsync(id);
            if (deviceCategory == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(deviceCategory);
        }

        // POST: DeviceCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _deviceCategoryService.DeleteDeviceCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

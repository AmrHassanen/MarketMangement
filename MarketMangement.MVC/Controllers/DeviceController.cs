using AutoMapper;
using MarketMangement.Service.DTOs;
using MarketMangement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketMangement.MVC.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IDeviceCategoryService _deviceCategoryService; // Service for fetching device categories
        private readonly IMapper _mapper;

        public DeviceController(IDeviceService deviceService, IDeviceCategoryService deviceCategoryService, IMapper mapper)
        {
            _deviceService = deviceService;
            _deviceCategoryService = deviceCategoryService;
            _mapper = mapper;
        }

        // GET: Device
        public async Task<IActionResult> Index()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return View(devices);
        }

        // GET: Device/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // GET: Device/Create
        public async Task<IActionResult> Create()
        {
            // Fetch device categories and assign to ViewBag
            var categories = await _deviceCategoryService.GetAllCategoriesAsync();
            ViewBag.DeviceCategories = categories.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.CategoryName
            });

            return View();
        }

        // POST: Device/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceDto deviceDto)
        {
            if (ModelState.IsValid)
            {
                await _deviceService.AddDeviceAsync(deviceDto);
                return RedirectToAction(nameof(Index));
            }

            // Fetch device categories again if model state is invalid
            var categories = await _deviceCategoryService.GetAllCategoriesAsync();
            ViewBag.DeviceCategories = categories.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.CategoryName
            });

            return View(deviceDto);
        }

        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            // Fetch device categories for the dropdown
            var categories = await _deviceCategoryService.GetAllCategoriesAsync();
            ViewBag.DeviceCategories = categories.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.CategoryName
            });

            return View(device);
        }

        // POST: Device/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeviceDto deviceDto)
        {
            if (id != deviceDto.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _deviceService.UpdateDeviceAsync(id, deviceDto);
                return RedirectToAction(nameof(Index));
            }

            // Fetch device categories again if model state is invalid
            var categories = await _deviceCategoryService.GetAllCategoriesAsync();
            ViewBag.DeviceCategories = categories.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.CategoryName
            });

            return View(deviceDto);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var device = await _deviceService.GetDeviceByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _deviceService.DeleteDeviceAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddPropertyItem(int deviceId)
        {
            var device = await _deviceService.GetDeviceByIdAsync(deviceId);
            if (device == null)
            {
                return NotFound();
            }

            var propertyItemDto = new PropertyItemDto { DeviceId = deviceId };
            return View(propertyItemDto);
        }

        // POST: Add PropertyItem to a Device
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPropertyItem(PropertyItemDto propertyItemDto)
        {
            if (ModelState.IsValid)
            {
                await _deviceService.AddPropertyItemAsync(propertyItemDto);
                return RedirectToAction(nameof(Details), new { id = propertyItemDto.DeviceId });
            }

            return View(propertyItemDto);
        }

        // GET: Edit PropertyItem
        public async Task<IActionResult> EditPropertyItem(int id)
        {
            var propertyItem = await _deviceService.GetPropertyItemByIdAsync(id);
            if (propertyItem == null)
            {
                return NotFound();
            }

            return View(propertyItem);
        }

        // POST: Edit PropertyItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPropertyItem(PropertyItemDto propertyItemDto)
        {
            if (ModelState.IsValid)
            {
                await _deviceService.UpdatePropertyItemAsync(propertyItemDto.Id, propertyItemDto);
                return RedirectToAction(nameof(Details), new { id = propertyItemDto.DeviceId });
            }

            return View(propertyItemDto);
        }

        // GET: Delete PropertyItem
        public async Task<IActionResult> DeletePropertyItem(int id)
        {
            var propertyItem = await _deviceService.GetPropertyItemByIdAsync(id);
            if (propertyItem == null)
            {
                return NotFound();
            }

            return View(propertyItem);
        }

        // POST: Delete PropertyItem
        [HttpPost, ActionName("DeletePropertyItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePropertyItemConfirmed(int id)
        {
            var propertyItem = await _deviceService.GetPropertyItemByIdAsync(id);
            await _deviceService.DeletePropertyItemAsync(id);
            return RedirectToAction(nameof(Details), new { id = propertyItem.DeviceId });
        }
    }
}

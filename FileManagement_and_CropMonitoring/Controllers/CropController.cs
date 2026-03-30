using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FarmManagement_and_CropMonitoring.Models;
using FarmManagement_and_CropMonitoring.Services.Interfaces;

namespace FarmManagement_and_CropMonitoring.Controllers
{
    public class CropController : Controller
    {
        private readonly ICropService _cropService;
        private readonly IFieldService _fieldService;

        public CropController(ICropService cropService, IFieldService fieldService)
        {
            _cropService = cropService;
            _fieldService = fieldService;
        }

        public async Task<IActionResult> Index()
        {
            var crops = await _cropService.GetAllCropsAsync();
            return View(crops);
        }

        public async Task<IActionResult> Create()
        {
            // Load fields for the dropdown
            var fields = await _fieldService.GetAllFieldsAsync();
            ViewBag.FieldId = new SelectList(fields, "FieldId", "FieldName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Crop crop)
        {
            if (ModelState.IsValid)
            {
                await _cropService.AddCropAsync(crop);
                return RedirectToAction(nameof(Index));
            }

            // If we reach here, validation failed, reload the dropdown
            var fields = await _fieldService.GetAllFieldsAsync();
            ViewBag.FieldId = new SelectList(fields, "FieldId", "FieldName");
            return View(crop);
        }
    }
}
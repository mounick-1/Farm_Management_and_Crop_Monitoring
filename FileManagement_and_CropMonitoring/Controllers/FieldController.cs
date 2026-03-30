using FarmManagement_and_CropMonitoring.Data;
using FarmManagement_and_CropMonitoring.Models;
using FarmManagement_and_CropMonitoring.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FarmManagement_and_CropMonitoring.Controllers
{
    public class FieldController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFieldService _fieldService; 

        // The Constructor MUST assign values to both
        public FieldController(ApplicationDbContext context, IFieldService fieldService)
        {
            _context = context;      
            _fieldService = fieldService;
        }

        public async Task<IActionResult> Index()
        {
            // The .Include(f => f.Crops) is the "magic" that links them in the view
            var fieldsWithCrops = await _context.Fields
                .Include(f => f.Crops)
                .ToListAsync();

            return View(await _context.Fields.Include(f => f.Crops).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Field field)
        {
            if (ModelState.IsValid)
            {
                await _fieldService.AddFieldAsync(field);
                return RedirectToAction(nameof(Index));
            }
            return View(field);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var field = await _fieldService.GetFieldByIdAsync(id);
            if (field == null) return NotFound();
            return View(field);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Field field)
        {
            if (id != field.FieldId) return BadRequest();

            if (ModelState.IsValid)
            {
                await _fieldService.UpdateFieldAsync(field);
                return RedirectToAction(nameof(Index));
            }
            return View(field);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _fieldService.DeleteFieldAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
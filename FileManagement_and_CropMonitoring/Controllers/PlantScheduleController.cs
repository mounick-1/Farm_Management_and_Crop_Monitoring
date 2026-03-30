using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmManagement_and_CropMonitoring.Data;
using FarmManagement_and_CropMonitoring.Models;

namespace FarmManagement_and_CropMonitoring.Controllers
{
    public class PlantScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schedules = await _context.PlantSchedules
                .Include(p => p.Crop)
                .Include(p => p.Field)
                .ToListAsync();
            return View(schedules);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CropId = new SelectList(await _context.Crops.ToListAsync(), "CropId", "CropName");
            ViewBag.FieldId = new SelectList(await _context.Fields.ToListAsync(), "FieldId", "FieldName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlantSchedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schedule);
        }
    }
}
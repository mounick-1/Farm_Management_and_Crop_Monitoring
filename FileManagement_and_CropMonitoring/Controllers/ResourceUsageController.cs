using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmManagement_and_CropMonitoring.Data;
using FarmManagement_and_CropMonitoring.Models;

namespace FarmManagement_and_CropMonitoring.Controllers
{
    public class ResourceUsageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourceUsageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usage = await _context.ResourceUsages
                .Include(r => r.Crop)
                .Include(r => r.Resource)
                .ToListAsync();
            return View(usage);
        }

        public async Task<IActionResult> Create()
        {
            // CRITICAL: This fills the dropdowns with real data from your DB
            ViewBag.CropId = new SelectList(await _context.Crops.ToListAsync(), "CropId", "CropName");
            ViewBag.ResourceId = new SelectList(await _context.Resources.ToListAsync(), "ResourceId", "ResourceName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ResourceUsage usage)
        {
            // 1. Find the resource in the database to check current stock
            var resourceInDb = await _context.Resources.FindAsync(usage.ResourceId);

            if (resourceInDb != null)
            {
                // Safety check start
                if (usage.QuantityUsed > resourceInDb.QuantityInStock)
                {
                    // Add a custom error message to the page
                    ModelState.AddModelError("QuantityUsed", $"Insufficient stock! Only {resourceInDb.QuantityInStock} {resourceInDb.Unit} available.");
                }
                // Safety check end
            }

            if (ModelState.IsValid)
            {
                if (resourceInDb != null)
                {
                    resourceInDb.QuantityInStock -= usage.QuantityUsed;
                    _context.Update(resourceInDb);
                }

                _context.Add(usage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If validation fails (insufficient stock), refill the dropdowns and show the error
            ViewBag.CropId = new SelectList(await _context.Crops.ToListAsync(), "CropId", "CropName");
            ViewBag.ResourceId = new SelectList(await _context.Resources.ToListAsync(), "ResourceId", "ResourceName");
            return View(usage);
        }
    }
}
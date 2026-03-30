using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmManagement_and_CropMonitoring.Data;

namespace FarmManagement_and_CropMonitoring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // This is the ONLY Index method that should be here
        public async Task<IActionResult> Index()
        {
            ViewBag.FieldCount = await _context.Fields.CountAsync();
            ViewBag.CropCount = await _context.Crops.CountAsync();
            ViewBag.ResourceCount = await _context.Resources.CountAsync();
            ViewBag.RecentUsage = await _context.ResourceUsages.CountAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
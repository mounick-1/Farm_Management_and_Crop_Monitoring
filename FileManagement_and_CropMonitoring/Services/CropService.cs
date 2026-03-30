using FarmManagement_and_CropMonitoring.Data;
using FarmManagement_and_CropMonitoring.Models;
using FarmManagement_and_CropMonitoring.Services.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FarmManagement_and_CropMonitoring.Services
{
    public class CropService : ICropService
    {
        private readonly ApplicationDbContext _context;

        public CropService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Crop>> GetAllCropsAsync()
        {
            // .Include(c => c.Field) ensures we get the Field name too!
            return await _context.Crops.Include(c => c.Field).ToListAsync();
        }

        public async Task<Crop?> GetCropByIdAsync(int id)
        {
            return await _context.Crops.Include(c => c.Field)
                .FirstOrDefaultAsync(m => m.CropId == id);
        }

        public async Task AddCropAsync(Crop crop)
        {
            _context.Add(crop);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCropAsync(Crop crop)
        {
            _context.Update(crop);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCropAsync(int id)
        {
            var crop = await _context.Crops.FindAsync(id);
            if (crop != null)
            {
                _context.Crops.Remove(crop);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using FarmManagement_and_CropMonitoring.Data;
using FarmManagement_and_CropMonitoring.Models;
using FarmManagement_and_CropMonitoring.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmManagement_and_CropMonitoring.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ApplicationDbContext _context;

        public ResourceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resource>> GetAllResourcesAsync()
        {
            return await _context.Resources.ToListAsync();
        }

        public async Task AddResourceAsync(Resource resource)
        {
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();
        }
    }
}
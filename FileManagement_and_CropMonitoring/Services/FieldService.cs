using FarmManagement_and_CropMonitoring.Data;
using FarmManagement_and_CropMonitoring.Models;
using FarmManagement_and_CropMonitoring.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarmManagement_and_CropMonitoring.Services
{
    public class FieldService : IFieldService
    {
        private readonly ApplicationDbContext _context;

        public FieldService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Field>> GetAllFieldsAsync()
        {
            return await _context.Fields.ToListAsync();
        }

        public async Task<Field?> GetFieldByIdAsync(int id)
        {
            return await _context.Fields.FindAsync(id);
        }

        public async Task AddFieldAsync(Field field)
        {
            _context.Add(field);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFieldAsync(Field field)
        {
            _context.Update(field);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFieldAsync(int id)
        {
            var field = await _context.Fields.FindAsync(id);
            if (field != null)
            {
                _context.Fields.Remove(field);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using FarmManagement_and_CropMonitoring.Models;

namespace FarmManagement_and_CropMonitoring.Services.Interfaces
{
    public interface IFieldService
    {
        Task<IEnumerable<Field>> GetAllFieldsAsync();
        Task<Field?> GetFieldByIdAsync(int id);
        Task AddFieldAsync(Field field);
        Task UpdateFieldAsync(Field field);
        Task DeleteFieldAsync(int id);
    }
}
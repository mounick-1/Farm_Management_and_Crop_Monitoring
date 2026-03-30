using FarmManagement_and_CropMonitoring.Models;

namespace FarmManagement_and_CropMonitoring.Services.Interfaces
{
    public interface ICropService
    {
        Task<IEnumerable<Crop>> GetAllCropsAsync();
        Task<Crop?> GetCropByIdAsync(int id);
        Task AddCropAsync(Crop crop);
        Task UpdateCropAsync(Crop crop);
        Task DeleteCropAsync(int id);
    }
}
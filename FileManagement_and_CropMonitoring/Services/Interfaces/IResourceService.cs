using FarmManagement_and_CropMonitoring.Models;

namespace FarmManagement_and_CropMonitoring.Services.Interfaces
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAllResourcesAsync();
        Task AddResourceAsync(Resource resource);
        // We can add Update/Delete later
    }
}
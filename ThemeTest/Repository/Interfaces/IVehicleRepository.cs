using ThemeTest.DB;
using ThemeTest.Models.Vehicles;

namespace ThemeTest.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> CreateAsync(Vehicle input);
        Task<Vehicle> UpdateAsync(Guid id,Vehicle input);
        Task DeleteAsync(Guid id);
        Task<Vehicle> GetAsync(Guid id);
        Task<List<Vehicle>> GetAllAsync();
    }
}

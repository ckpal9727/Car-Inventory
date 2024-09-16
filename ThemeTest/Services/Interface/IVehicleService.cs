using ThemeTest.Models.Vehicles;

namespace ThemeTest.Services.Interface
{
    public interface IVehicleService
    {
        Task<VehicleDto> CreateAsync(VehicleCreateDto input);
        Task<VehicleDto> UpdateAsync(Guid id,VehicleUpdateDto input);
        Task DeleteAsync(Guid  id);
        Task<VehicleDto> GetAsync(Guid id);
        Task<List<VehicleDto>> GetAllAsync();
    }
}

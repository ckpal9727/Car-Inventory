using Microsoft.EntityFrameworkCore;
using ThemeTest.DB;
using ThemeTest.Models.Vehicles;
using ThemeTest.Repository.Interfaces;

namespace ThemeTest.Repository.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public VehicleRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<Vehicle> CreateAsync(Vehicle input)
        {
            var result= await _dataBaseContext.Vehicles.AddAsync(input);
            await _dataBaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var vehicle = await _dataBaseContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                throw new KeyNotFoundException("Vehicle not found");
            }

            _dataBaseContext.Vehicles.Remove(vehicle);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _dataBaseContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetAsync(Guid id)
        {
            var vehicle = await _dataBaseContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                throw new KeyNotFoundException("Vehicle not found");
            }
            return vehicle;
        }

        public async Task<Vehicle> UpdateAsync(Guid id,Vehicle input)
        {
            var existingVehicle = await _dataBaseContext.Vehicles.FindAsync(id);
            if (existingVehicle == null)
            {
                throw new KeyNotFoundException("Vehicle not found");
            }

            // Update fields (example: if you have properties like Name and Model)
            existingVehicle.Category = input.Category;
            existingVehicle.Model = input.Model;
            existingVehicle.Status = input.Status;
            existingVehicle.Make = input.Make;
            existingVehicle.PricePerDay= input.PricePerDay;
            existingVehicle.Year= input.Year;

            // Update other properties as needed

            // No need to call AddAsync since we're updating an existing entity
            _dataBaseContext.Vehicles.Update(existingVehicle);
            await _dataBaseContext.SaveChangesAsync();

            return existingVehicle;
        }

    }
}

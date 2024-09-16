using AutoMapper;
using ThemeTest.DB;
using ThemeTest.Models.Vehicles;
using ThemeTest.Repository.Interfaces;
using ThemeTest.Services.Interface;

namespace ThemeTest.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(
            IVehicleRepository vehicleRepository,
            IMapper mapper
            )
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<VehicleDto> CreateAsync(VehicleCreateDto input)
        {
            return _mapper.Map<VehicleDto>(await _vehicleRepository.CreateAsync(_mapper.Map<Vehicle>(input)));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _vehicleRepository.DeleteAsync(id);
        }

        public async Task<List<VehicleDto>> GetAllAsync()
        {
            return _mapper.Map<List<VehicleDto>>(await _vehicleRepository.GetAllAsync());
        }

        public async Task<VehicleDto> GetAsync(Guid id)
        {
            return  _mapper.Map<VehicleDto>(await _vehicleRepository.GetAsync(id));
        }

        public async Task<VehicleDto> UpdateAsync(Guid id,VehicleUpdateDto input)
        {
            return _mapper.Map<VehicleDto>(await _vehicleRepository.UpdateAsync(id,_mapper.Map<Vehicle>(input)));
        }
    }
}

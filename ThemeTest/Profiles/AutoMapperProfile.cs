using AutoMapper;
using ThemeTest.DB;
using ThemeTest.Models.Vehicles;

namespace ThemeTest.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<Vehicle, VehicleCreateDto>().ReverseMap();
            CreateMap<Vehicle, VehicleUpdateDto>().ReverseMap();
        }
    }
}

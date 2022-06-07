using AutoMapper;
using EmployeeApp.Services.EmployeeAPI.Models;
using EmployeeApp.Services.EmployeeAPI.Models.Dto;

namespace EmployeeApp.Services.EmployeeAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDto, Employee>().ReverseMap();
                config.CreateMap<PositionDto, Position>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}

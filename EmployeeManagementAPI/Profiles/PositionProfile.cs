using AutoMapper;

namespace EmployeeManagementAPI.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
             CreateMap<Entities.Position, Models.PositionDto>();
             CreateMap<Models.PositionForCreationDto, Entities.Position>();
        }
    }
}
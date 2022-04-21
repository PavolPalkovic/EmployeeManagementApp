using AutoMapper;

namespace EmployeeManagementAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Creats mapping <Source, Destination>
            CreateMap<Entities.Employee, Models.EmployeeDto>();
            CreateMap<Models.EmployeeForCreationUpdateDto, Entities.Employee>();
            CreateMap<Entities.Employee, Models.EmployeeForCreationUpdateDto>();
        }
    }
}
using AutoMapper;

namespace EmployeeManagementAPI.Profiles
{
    public class EmployeeHistoryProfile : Profile
    {
        public EmployeeHistoryProfile()
        {
            // Creats mapping <Source, Destination>
            CreateMap<Entities.EmployeeHistory, Models.EmployeeHistoryDto>();
            CreateMap<Models.EmployeeHistoryForCreationDto, Entities.EmployeeHistory>();
        }
    }
}
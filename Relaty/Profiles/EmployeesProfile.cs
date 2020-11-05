using AutoMapper;
using Relaty.Dtos;
using Relaty.Models;

namespace Relaty.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeWithProjectsDto>();
            CreateMap<ProjectEmployee, EmployeeProjectDto>();
        }
    }
}

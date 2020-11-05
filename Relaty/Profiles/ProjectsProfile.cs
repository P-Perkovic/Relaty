using AutoMapper;
using Relaty.Dtos;
using Relaty.Models;

namespace Relaty.Profiles
{
    public class ProjectsProfile : Profile
    {
        public ProjectsProfile()
        {
            //        Source --> Target
            CreateMap<Project, Project>();
            CreateMap<Project, ProjectDto>();
            CreateMap<Project, ProjectWithEmployeesDto>();
            CreateMap<ProjectEmployee, ProjectEmployeeDto>();

            CreateMap<ProjectDto, Project>();
        }
    }
}

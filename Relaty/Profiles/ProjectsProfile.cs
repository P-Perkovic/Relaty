using AutoMapper;
using Relaty.Dtos;
using Relaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Profiles
{
    public class ProjectsProfile : Profile
    {
        public ProjectsProfile()
        {
            //        Source --> Target
            CreateMap<Project, ProjectDto>();
            CreateMap<Project, ProjectWithEmployeesDto>();
            CreateMap<ProjectEmployee, ProjectEmployeesDto>();

            CreateMap<ProjectDto, Project>();
        }
    }
}

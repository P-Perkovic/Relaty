using AutoMapper;
using Relaty.Dtos;
using Relaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeWithProjectsDto>();
            CreateMap<ProjectEmployee, EmployeeProjectsDto>();
        }
    }
}

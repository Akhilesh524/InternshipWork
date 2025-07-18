using AutoMapper;
using EmployeeLeaveManagementSystem.Dto;
using EmployeeLeaveManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.MappingProfiles
{
   public class Mapping:Profile
    {
       public Mapping()
        {
            CreateMap<EmployeeDto, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeDto>();

            CreateMap<LeaveRequestsDto, LeaveRequestsEntity>();
            CreateMap<LeaveRequestsEntity, LeaveRequestsDto>();

            CreateMap<LeaveTypesDto, LeaveTypesEntity>();
            CreateMap<LeaveTypesEntity, LeaveTypesDto>();
        }
    }
}

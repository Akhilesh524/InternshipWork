using AutoMapper;
using EmployeeLeavesManagement.Dto;
using EmployeeLeavesManagement.Persistence.Entities;

namespace EmployeeLeavesManagement.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeEntity>();
            CreateMap<EmployeeEntity, Employee>();

            CreateMap<LeaveRequests, LeaveRequestsEntity>();
            CreateMap<LeaveRequestsEntity, LeaveRequests>();

            CreateMap<LeaveTypes, LeaveTypesEntity>();
            CreateMap<LeaveTypesEntity, LeaveTypes>();


        }
    }
}

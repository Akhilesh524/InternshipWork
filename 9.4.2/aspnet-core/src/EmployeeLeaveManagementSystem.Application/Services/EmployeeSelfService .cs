using Abp.Application.Services;
using Abp.Authorization;
using Abp.Runtime.Session;
using Abp.UI;
using EmployeeLeaveManagementSystem.Authorization;
using EmployeeLeaveManagementSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Services
{
    [AbpAuthorize]
    public class EmployeeSelfService : ApplicationService
    {
        private readonly LeaveRequestsService _leaveRequestsService;

        public EmployeeSelfService(LeaveRequestsService leaveRequestsService)
        {
            _leaveRequestsService = leaveRequestsService;
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_Create)]
        public async Task<LeaveRequestsDto> CreateLeaveRequest(LeaveRequestsDto input)
        {
            return await _leaveRequestsService.CreateLeaveRequests(input);
        }

       
        }

      
    }

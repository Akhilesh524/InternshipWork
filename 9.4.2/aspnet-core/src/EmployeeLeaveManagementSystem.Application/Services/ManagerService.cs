using Abp.Application.Services;
using Abp.Authorization;
using EmployeeLeaveManagementSystem.Authorization;
using EmployeeLeaveManagementSystem.Authorization.Users;
using EmployeeLeaveManagementSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Services
{
    [AbpAuthorize]
    public class ManagerService : ApplicationService
    {
        private readonly LeaveRequestsService _leaveRequestsService;
        private readonly UserManager _userManager;

        public ManagerService(LeaveRequestsService leaveRequestsService, UserManager userManager)
        {
            _leaveRequestsService = leaveRequestsService;
            _userManager = userManager;
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_View_All)]
        public async Task<List<LeaveRequestsDto>> GetAllLeaveRequestsAsync()
        {
            return await _leaveRequestsService.GetAllLeaveRequests();
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_ApproveReject)]
        public async Task<LeaveRequestsDto> ApproveOrRejectLeaveRequest(Guid requestId, bool approve)
        {
            return await _leaveRequestsService.ApproveOrRejectLeaveRequest(requestId, approve);
        }
    }

}

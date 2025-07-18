using Abp.Application.Services;
using Abp.Authorization;
using Abp.Runtime.Session;
using EmployeeLeaveManagementSystem.Authorization;
using EmployeeLeaveManagementSystem.Authorization.Users;
using EmployeeLeaveManagementSystem.Dto;
using EmployeeLeaveManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Founder
{
    [AbpAuthorize] // Restrict to authorized users
    public class FounderService : ApplicationService
    {
        private readonly EmployeeServices _employeeService;
        private readonly LeaveRequestsService _leaveRequestsService;
        private readonly LeaveTypesServices _leaveTypesService;
        private readonly UserManager _userManager;

        public FounderService(
            EmployeeServices employeeService,
            LeaveRequestsService leaveRequestsService,
            LeaveTypesServices leaveTypesService,
            UserManager userManager)
        {
            _employeeService = employeeService;
            _leaveRequestsService = leaveRequestsService;
            _leaveTypesService = leaveTypesService;
            _userManager = userManager;
        }

        private async Task<bool> IsCurrentUserInRoleAsync(string roleName)
        {
            var userId = AbpSession.GetUserId();
            var user = await _userManager.GetUserByIdAsync(userId);
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        // 📌 View all employees (Permission: Employee_View)
        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            if (!await PermissionChecker.IsGrantedAsync(PermissionNames.Employee_View))
                throw new AbpAuthorizationException("Not authorized to view employees.");

            return await _employeeService.GetAllEmployee();
        }

        // 📌 View all leave types (Permission: LeaveType_View)
        public async Task<List<LeaveTypesDto>> GetAllLeaveTypesAsync()
        {
            if (!await PermissionChecker.IsGrantedAsync(PermissionNames.LeaveType_View))
                throw new AbpAuthorizationException("Not authorized to view leave types.");

            return await _leaveTypesService.GetAllLeaveTypes();
        }

        // 📌 View all leave requests (Permission: LeaveRequest_View_All)
        public async Task<List<LeaveRequestsDto>> GetAllLeaveRequestsAsync()
        {
            if (!await PermissionChecker.IsGrantedAsync(PermissionNames.LeaveRequest_View_All))
                throw new AbpAuthorizationException("Not authorized to view leave requests.");

            return await _leaveRequestsService.GetAllLeaveRequests();
        }

        // 📌 Approve or reject leave request (Permission: LeaveRequest_ApproveReject)
        public async Task<LeaveRequestsDto> ApproveOrRejectLeaveRequest(Guid requestId, bool approve)
        {
            if (!await PermissionChecker.IsGrantedAsync(PermissionNames.LeaveRequest_ApproveReject))
                throw new AbpAuthorizationException("Not authorized to approve/reject leave requests.");

            return await _leaveRequestsService.ApproveOrRejectLeaveRequest(requestId, approve);
        }
    }
}



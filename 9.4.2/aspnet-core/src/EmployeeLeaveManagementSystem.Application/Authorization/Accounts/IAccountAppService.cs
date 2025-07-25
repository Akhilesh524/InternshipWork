﻿using System.Threading.Tasks;
using Abp.Application.Services;
using EmployeeLeaveManagementSystem.Authorization.Accounts.Dto;

namespace EmployeeLeaveManagementSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using EmployeeLeaveManagementSystem.Authorization.Roles;
using EmployeeLeaveManagementSystem.Authorization.Users;
using EmployeeLeaveManagementSystem.MultiTenancy;
using Microsoft.Extensions.Logging;
using Abp.Domain.Uow;

namespace EmployeeLeaveManagementSystem.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ILoggerFactory loggerFactory,
            IUnitOfWorkManager unitOfWorkManager)
            : base(options, signInManager, loggerFactory, unitOfWorkManager)
        {
        }
    }
}

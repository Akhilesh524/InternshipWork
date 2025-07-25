﻿using Abp.Authorization;
using Abp.Domain.Uow;
using EmployeeLeaveManagementSystem.Authorization;
using EmployeeLeaveManagementSystem.Authorization.Roles;
using EmployeeLeaveManagementSystem.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.EntityFrameworkCore.Seed
{
    public class RolesDataSeeder
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IPermissionManager _permissionManager;
       

        public RolesDataSeeder(
            RoleManager roleManager,  
            UserManager userManager,
            IUnitOfWorkManager unitOfWorkManager,
            IPermissionManager permissionManager
           )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _unitOfWorkManager = unitOfWorkManager;
            _permissionManager = permissionManager;
           
        }

        public async Task SeedAsync()
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
             
                var founderRole = await CreateRoleIfNotExists("Founder");
                var managerRole = await CreateRoleIfNotExists("Manager");
                var employeeRole = await CreateRoleIfNotExists("Employee");

             
                await _roleManager.GrantAllPermissionsAsync(founderRole); // All for Founder

                // Manager-specific
                await GrantPermissionByNameAsync(managerRole, PermissionNames.Employee_View);
                await GrantPermissionByNameAsync(managerRole, PermissionNames.LeaveType_View);
                await GrantPermissionByNameAsync(managerRole, PermissionNames.LeaveRequest_View_All);
                await GrantPermissionByNameAsync(managerRole, PermissionNames.LeaveRequest_ApproveReject);

                // Employee-specific
                await GrantPermissionByNameAsync(employeeRole, PermissionNames.LeaveRequest_Create);
                await GrantPermissionByNameAsync(employeeRole, PermissionNames.LeaveRequest_View_Own);
                await GrantPermissionByNameAsync(employeeRole, PermissionNames.LeaveRequest_Cancel_Own);
                await GrantPermissionByNameAsync(employeeRole, PermissionNames.LeaveType_View);

                // Step 3: Create Founder user only if it doesn't exist
                await CreateUserIfNotExists("founder@demo.com", "Founder", founderRole.Name);

                await uow.CompleteAsync();
            }
        }

        private async Task<Role> CreateRoleIfNotExists(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new Role(null, roleName, roleName);
                await _roleManager.CreateAsync(role);
            }
            return role;
        }

        private async Task GrantPermissionByNameAsync(Role role, string permissionName)
        {
            var permission = _permissionManager.GetPermission(permissionName);
            if (permission != null)
            {
                await _roleManager.GrantPermissionAsync(role, permission);
            }
        }

        private async Task CreateUserIfNotExists(string email, string displayName, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    TenantId = null, // Host-level user
                    UserName = email.Split('@')[0],
                    Name = displayName,
                    Surname = "User",
                    EmailAddress = email,
                    IsEmailConfirmed = true,
                    IsActive = true
                };
                user.SetNormalizedNames();

                var result = await _userManager.CreateAsync(user, "123qwe");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                  
                }
            }
        }
    }
}





using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using EmployeeLeaveManagementSystem.Authorization;
using EmployeeLeaveManagementSystem.Authorization.Roles;
using EmployeeLeaveManagementSystem.Authorization.Users;

namespace EmployeeLeaveManagementSystem.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly EmployeeLeaveManagementSystemDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(EmployeeLeaveManagementSystemDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            CreateRoleWithUser("Founder", "founder@tenant.com", "123qwe", isStatic: true, grantAllPermissions: true);
            CreateRoleWithUser("Manager", "manager@tenant.com", "123qwe");
            CreateRoleWithUser("Employee", "employee@tenant.com", "123qwe");
        }

        private void CreateRoleWithUser(string roleName, string email, string password, bool isStatic = false, bool grantAllPermissions = false)
        {
            // 1. Role
            var role = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r => r.TenantId == _tenantId && r.Name == roleName);
            if (role == null)
            {
                role = _context.Roles.Add(new Role(_tenantId, roleName, roleName) { IsStatic = isStatic }).Entity;
                _context.SaveChanges();
            }

            // 2. Permissions (if grantAllPermissions = true)
            if (grantAllPermissions)
            {
                var grantedPermissions = _context.Permissions.IgnoreQueryFilters()
                    .OfType<RolePermissionSetting>()
                    .Where(p => p.TenantId == _tenantId && p.RoleId == role.Id)
                    .Select(p => p.Name)
                    .ToList();

                var permissions = PermissionFinder
                    .GetAllPermissions(new EmployeeLeaveManagementSystemAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) &&
                                !grantedPermissions.Contains(p.Name))
                    .ToList();

                if (permissions.Any())
                {
                    _context.Permissions.AddRange(
                        permissions.Select(permission => new RolePermissionSetting
                        {
                            TenantId = _tenantId,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = role.Id
                        })
                    );
                    _context.SaveChanges();
                }
            }

            // 3. User
            var user = _context.Users.IgnoreQueryFilters().FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == roleName.ToLower());
            if (user == null)
            {
                user = User.CreateTenantAdminUser(_tenantId, email);
                user.UserName = roleName.ToLower();
                user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions()))
                    .HashPassword(user, password);
                user.IsEmailConfirmed = true;
                user.IsActive = true;

                _context.Users.Add(user);
                _context.SaveChanges();

                // 4. Assign Role to User
                _context.UserRoles.Add(new UserRole(_tenantId, user.Id, role.Id));
                _context.SaveChanges();
            }
        }
    }
}


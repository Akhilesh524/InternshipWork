using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using EmployeeLeaveManagementSystem.Authorization.Roles;
using EmployeeLeaveManagementSystem.Authorization.Users;
using EmployeeLeaveManagementSystem.EntityFrameworkCore.Seed.Host;
using EmployeeLeaveManagementSystem.EntityFrameworkCore.Seed.Tenants;
using Abp.Authorization;
using Abp.EntityFrameworkCore.Uow;

namespace EmployeeLeaveManagementSystem.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<EmployeeLeaveManagementSystemDbContext>(iocResolver, context =>
            {
                context.SuppressAutoSetTenantId = true;

                // Seed the host and default tenant data
                new InitialHostDbBuilder(context).Create();
                new DefaultTenantBuilder(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();

                // Resolve dependencies for your roles seeder
                var roleManager = iocResolver.Resolve<RoleManager>();
                var userManager = iocResolver.Resolve<UserManager>();
                var unitOfWorkManager = iocResolver.Resolve<IUnitOfWorkManager>();
                var permissionManager = iocResolver.Resolve<IPermissionManager>();

                var seeder = new RolesDataSeeder(roleManager, userManager, unitOfWorkManager, permissionManager);
                seeder.SeedAsync().GetAwaiter().GetResult();
            });
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);
                    contextAction(context);
                    uow.Complete();
                }
            }
        }
    }
}




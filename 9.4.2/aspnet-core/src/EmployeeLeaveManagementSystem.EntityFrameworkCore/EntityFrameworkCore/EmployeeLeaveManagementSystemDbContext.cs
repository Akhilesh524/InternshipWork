using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EmployeeLeaveManagementSystem.Authorization.Roles;
using EmployeeLeaveManagementSystem.Authorization.Users;
using EmployeeLeaveManagementSystem.MultiTenancy;
using EmployeeLeaveManagementSystem.Entities;

namespace EmployeeLeaveManagementSystem.EntityFrameworkCore
{
    public class EmployeeLeaveManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, EmployeeLeaveManagementSystemDbContext>
    {
        public EmployeeLeaveManagementSystemDbContext(DbContextOptions<EmployeeLeaveManagementSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<LeaveRequestsEntity> LeaveRequests { get; set; }
        public DbSet<LeaveTypesEntity> LeaveTypes { get; set; }
    }
}


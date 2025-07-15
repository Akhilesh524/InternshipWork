using EmployeeLeavesManagement.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeavesManagement.Persistence
{
    public class EmployeeLeavesDbContext : DbContext
    {
        

        public EmployeeLeavesDbContext(DbContextOptions<EmployeeLeavesDbContext> options) : base(options)
        {

        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<LeaveRequestsEntity> LeaveRequests { get; set; }
        public DbSet<LeaveTypesEntity> LeaveTypes{ get; set; }

    }
}

using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystem.EntityFrameworkCore
{
    public static class EmployeeLeaveManagementSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EmployeeLeaveManagementSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EmployeeLeaveManagementSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

﻿namespace EmployeeLeaveManagementSystem.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly EmployeeLeaveManagementSystemDbContext _context;

        public InitialHostDbBuilder(EmployeeLeaveManagementSystemDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}

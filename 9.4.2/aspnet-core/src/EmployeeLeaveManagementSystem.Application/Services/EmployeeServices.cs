using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using EmployeeLeaveManagementSystem.Authorization;  // Make sure PermissionNames is in this namespace
using EmployeeLeaveManagementSystem.Dto;
using EmployeeLeaveManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Services
{
    [AbpAuthorize]
    public class EmployeeServices : ApplicationService
    {
        private readonly IRepository<EmployeeEntity, Guid> _repo;
        private readonly IMapper _mapper;

        public EmployeeServices(IRepository<EmployeeEntity, Guid> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Employee_Create)]
        public async Task<EmployeeDto> CreateEmployee(EmployeeDto input)
        {
            var entity = _mapper.Map<EmployeeDto, EmployeeEntity>(input);
            var inserted = await _repo.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return _mapper.Map<EmployeeEntity, EmployeeDto>(inserted);
        }

        [AbpAuthorize(PermissionNames.Employee_View)]
        public async Task<EmployeeDto?> GetEmployeeById(Guid id)
        {
            var employee = await _repo.FirstOrDefaultAsync(id);
            if (employee == null)
                return null;
            return _mapper.Map<EmployeeDto>(employee);
        }

        [AbpAuthorize(PermissionNames.Employee_View)]
        public async Task<List<EmployeeDto>> GetAllEmployee()
        {
            var employees = await _repo.GetAllListAsync();
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        [AbpAuthorize(PermissionNames.Employee_Update)]
        public async Task<EmployeeDto?> UpdateEmployeeById(Guid id, EmployeeDto input)
        {
            var employee = await _repo.FirstOrDefaultAsync(id);
            if (employee == null)
                return null;

            employee.FirstName = input.FirstName;
            employee.LastName = input.LastName;
            employee.Email = input.Email;
            employee.DateOfJoining = input.DateOfJoining;

            await _repo.UpdateAsync(employee);
            return _mapper.Map<EmployeeDto>(employee);
        }

        [AbpAuthorize(PermissionNames.Employee_Delete)]
        public async Task DeleteEmployeeById(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}







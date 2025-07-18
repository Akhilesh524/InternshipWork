using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using EmployeeLeaveManagementSystem.Authorization; // Ensure PermissionNames is here
using EmployeeLeaveManagementSystem.Dto;
using EmployeeLeaveManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Services
{
    [AbpAuthorize] // Require authentication for all methods
    public class LeaveTypesServices : ApplicationService
    {
        private readonly IRepository<LeaveTypesEntity, Guid> _repo;
        private readonly IMapper _mapper;

        public LeaveTypesServices(IRepository<LeaveTypesEntity, Guid> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.LeaveType_Create)]
        public async Task<LeaveTypesDto> CreateLeaveTypes(LeaveTypesDto input)
        {
            var entity = _mapper.Map<LeaveTypesEntity>(input);
            var inserted = await _repo.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return _mapper.Map<LeaveTypesDto>(inserted);
        }

        [AbpAuthorize(PermissionNames.LeaveType_View)]
        public async Task<LeaveTypesDto?> GetLeaveTypesId(Guid id)
        {
            var leave = await _repo.FirstOrDefaultAsync(id);
            return leave == null ? null : _mapper.Map<LeaveTypesDto>(leave);
        }

        [AbpAuthorize(PermissionNames.LeaveType_View)]
        public async Task<List<LeaveTypesDto>> GetAllLeaveTypes()
        {
            var leave = await _repo.GetAllListAsync();
            return _mapper.Map<List<LeaveTypesDto>>(leave);
        }

        [AbpAuthorize(PermissionNames.LeaveType_Update)]
        public async Task<LeaveTypesDto?> UpdateLeaveTypesById(Guid id, LeaveTypesDto input)
        {
            var leaveType = await _repo.FirstOrDefaultAsync(id);
            if (leaveType == null)
                return null;

            _mapper.Map(input, leaveType);
            await _repo.UpdateAsync(leaveType);
            return _mapper.Map<LeaveTypesDto>(leaveType);
        }

        [AbpAuthorize(PermissionNames.LeaveType_Delete)]
        public async Task DeleteLeaveTypesById(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}


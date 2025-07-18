using Abp.Authorization;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using EmployeeLeaveManagementSystem.Authorization;
using EmployeeLeaveManagementSystem.Dto;
using EmployeeLeaveManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.UI;
using EmployeeLeaveManagementSystem.enums;

namespace EmployeeLeaveManagementSystem.Services
{
    [AbpAuthorize] // Optional: protects all methods; use with specific permissions on methods if preferred
    public class LeaveRequestsService : ApplicationService
    {
        private readonly IRepository<LeaveRequestsEntity, Guid> _repo;
        private readonly IMapper _mapper;

        public LeaveRequestsService(IRepository<LeaveRequestsEntity, Guid> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_Create)]
        public async Task<LeaveRequestsDto> CreateLeaveRequests(LeaveRequestsDto input)
        {
            var entity = _mapper.Map<LeaveRequestsDto, LeaveRequestsEntity>(input);
            var inserted = await _repo.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();
            return _mapper.Map<LeaveRequestsEntity, LeaveRequestsDto>(inserted);
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_View_All, PermissionNames.LeaveRequest_View_Own)]
        public async Task<LeaveRequestsDto?> GetLeaveRequestsById(Guid id)
        {
            var leave = await _repo.FirstOrDefaultAsync(id);
            if (leave == null)
                return null;
            return _mapper.Map<LeaveRequestsDto>(leave);
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_View_All, PermissionNames.LeaveRequest_View_Own)]
        public async Task<List<LeaveRequestsDto>> GetAllLeaveRequests()
        {
            var allleave = await _repo.GetAllListAsync();
            return _mapper.Map<List<LeaveRequestsDto>>(allleave);
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_ApproveReject)] // Typically only Founder and Manager
        public async Task<LeaveRequestsDto?> UpdateLeaveRequestsById(Guid id, LeaveRequestsDto input)
        {
            var leave = await _repo.FirstOrDefaultAsync(id);
            if (leave == null)
                return null;

            _mapper.Map(input, leave);
            await _repo.UpdateAsync(leave);
            return _mapper.Map<LeaveRequestsDto>(leave);
        }

        [AbpAuthorize(PermissionNames.LeaveRequest_Cancel_Own, PermissionNames.LeaveRequest_ApproveReject)]
        public async Task DeleteLeaveRequestsById(Guid id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<LeaveRequestsDto> ApproveOrRejectLeaveRequest(Guid requestId, bool approve)
        {
            try
            {
                var leave = await _repo.FirstOrDefaultAsync(requestId);
                if (leave == null)
                    throw new UserFriendlyException("Leave request not found.");

                leave.Status = (approve ? LeaveRequests.Approved : LeaveRequests.Rejected).ToString();

                await _repo.UpdateAsync(leave);

                return _mapper.Map<LeaveRequestsDto>(leave);
            }
            catch (Exception ex)
            {
                Logger.Error("Error in ApproveOrRejectLeaveRequest", ex);
                throw new UserFriendlyException("Failed to update leave request: " + ex.Message);
            }
        }






    }
}


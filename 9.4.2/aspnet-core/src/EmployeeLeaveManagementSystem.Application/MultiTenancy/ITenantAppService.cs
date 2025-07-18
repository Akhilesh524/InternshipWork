using Abp.Application.Services;
using EmployeeLeaveManagementSystem.MultiTenancy.Dto;

namespace EmployeeLeaveManagementSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


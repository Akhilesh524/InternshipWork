using System.Threading.Tasks;
using Abp.Application.Services;
using EmployeeLeaveManagementSystem.Sessions.Dto;

namespace EmployeeLeaveManagementSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

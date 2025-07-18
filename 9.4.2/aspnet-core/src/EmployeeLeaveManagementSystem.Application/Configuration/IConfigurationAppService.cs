using System.Threading.Tasks;
using EmployeeLeaveManagementSystem.Configuration.Dto;

namespace EmployeeLeaveManagementSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

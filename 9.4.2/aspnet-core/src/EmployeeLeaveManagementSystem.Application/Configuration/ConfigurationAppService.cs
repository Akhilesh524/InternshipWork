using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EmployeeLeaveManagementSystem.Configuration.Dto;

namespace EmployeeLeaveManagementSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EmployeeLeaveManagementSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

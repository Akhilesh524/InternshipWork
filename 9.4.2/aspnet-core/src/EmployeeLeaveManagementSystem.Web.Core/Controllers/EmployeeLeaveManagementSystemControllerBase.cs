using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EmployeeLeaveManagementSystem.Controllers
{
    public abstract class EmployeeLeaveManagementSystemControllerBase: AbpController
    {
        protected EmployeeLeaveManagementSystemControllerBase()
        {
            LocalizationSourceName = EmployeeLeaveManagementSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

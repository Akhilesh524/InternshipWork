using Abp.Application.Services;
using Abp.Authorization;
using EmployeeLeaveManagementSystem.Authorization;
using System.Threading.Tasks;

public class SomeService : ApplicationService
{
    private readonly IPermissionChecker _permissionChecker;

    public SomeService(IPermissionChecker permissionChecker)
    {
        _permissionChecker = permissionChecker;
    }

    public async Task SomeMethod()
    {
        if (await _permissionChecker.IsGrantedAsync(PermissionNames.Employee_View))
        {
            // Proceed
        }
        else
        {
            throw new AbpAuthorizationException("Permission denied.");
        }
    }
}

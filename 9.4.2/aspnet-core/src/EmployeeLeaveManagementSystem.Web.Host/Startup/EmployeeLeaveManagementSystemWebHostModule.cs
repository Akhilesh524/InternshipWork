using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EmployeeLeaveManagementSystem.Configuration;

namespace EmployeeLeaveManagementSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(EmployeeLeaveManagementSystemWebCoreModule))]
    public class EmployeeLeaveManagementSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EmployeeLeaveManagementSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.MultiTenancy.IsEnabled = true; 
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EmployeeLeaveManagementSystemWebHostModule).GetAssembly());
        }
    }
}

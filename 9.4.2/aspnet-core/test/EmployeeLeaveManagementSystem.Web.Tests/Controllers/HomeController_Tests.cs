using System.Threading.Tasks;
using EmployeeLeaveManagementSystem.Models.TokenAuth;
using EmployeeLeaveManagementSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace EmployeeLeaveManagementSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: EmployeeLeaveManagementSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
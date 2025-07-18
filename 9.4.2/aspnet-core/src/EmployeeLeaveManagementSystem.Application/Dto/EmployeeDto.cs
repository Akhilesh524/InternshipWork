using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Dto
{
  public class EmployeeDto: EntityDto<Guid>
    {

      

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string Email { get; set; }

        public DateOnly DateOfJoining { get; set; }


    }
}

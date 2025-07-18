using Abp.Application.Services.Dto;
using EmployeeLeaveManagementSystem.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Dto
{
  public class LeaveTypesDto:EntityDto<Guid>
    {
        public LeaveTypes Name { get; set; }

        public int MaxDaysAllowed { get; set; }
    }
}

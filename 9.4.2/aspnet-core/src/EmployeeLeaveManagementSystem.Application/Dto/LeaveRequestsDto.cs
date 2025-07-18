using Abp.Application.Services.Dto;
using EmployeeLeaveManagementSystem.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Dto
{
  public class LeaveRequestsDto:EntityDto<Guid>
    {

        public Guid EmployeeId { get; set; }

        public Guid LeaveTypeId { get; set; }

        public DateOnly FromTo { get; set; }

        public DateOnly ToDate { get; set; }

        public LeaveRequests Status { get; set; }
    }
}

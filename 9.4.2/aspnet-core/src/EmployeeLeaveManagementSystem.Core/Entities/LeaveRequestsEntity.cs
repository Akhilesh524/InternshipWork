using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Entities
{
   public class LeaveRequestsEntity:Entity<Guid>
    {


        public Guid EmployeeId { get; set; }

        public Guid LeaveTypeId { get; set; }

        public DateOnly FromTo { get; set; }

        public DateOnly ToDate { get; set; }

        public string Status { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual EmployeeEntity Employee { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveTypesEntity LeaveType { get; set; }
        
    }
}

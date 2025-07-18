using Abp.Domain.Entities;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagementSystem.Entities
{
    public class LeaveTypesEntity:Entity<Guid>
    {

        public string Name { get; set; }

        public int MaxDaysAllowed { get; set; }

        public virtual ICollection<LeaveRequestsEntity> LeaveRequests { get; set; }
    }
}

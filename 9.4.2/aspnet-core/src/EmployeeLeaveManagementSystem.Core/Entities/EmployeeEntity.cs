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
   public class EmployeeEntity:Entity<Guid>
    {
     

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string Email { get; set; }

        public DateOnly DateOfJoining { get; set; }

        public virtual ICollection<LeaveRequestsEntity> LeaveRequests { get; set; }
    }
}

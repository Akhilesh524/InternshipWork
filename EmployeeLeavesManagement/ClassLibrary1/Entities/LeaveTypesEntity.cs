using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeavesManagement.Persistence.Entities
{
    public class LeaveTypesEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Name { get; set; }

        [Required]
        public int MaxDaysAllowed { get; set; }

        public virtual ICollection<LeaveRequestsEntity> LeaveRequests { get; set; }

    }
}

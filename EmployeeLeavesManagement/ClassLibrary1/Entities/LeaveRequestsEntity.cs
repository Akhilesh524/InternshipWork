using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeavesManagement.Persistence.Entities
{
    public class LeaveRequestsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }

        public DateOnly FromDate { get; set; }

        public DateOnly ToDate { get; set; }

        public string? Stutus { get; set; }

        
        [ForeignKey("EmployeeId")]
        public virtual EmployeeEntity Employee { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveTypesEntity LeaveType { get; set; }
    }

}

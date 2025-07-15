using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeavesManagement.Dto
{
    public class LeaveRequests
    {
      
        public int id { get; set; } 

     
        public int EmployeeId { get; set; } 

      
        public int LeaveTypeId { get; set; } 

        public DateOnly FromDate { get; set; }

        public DateOnly ToDate { get; set; }

        public String Stutus { get; set; }

      

    }
}

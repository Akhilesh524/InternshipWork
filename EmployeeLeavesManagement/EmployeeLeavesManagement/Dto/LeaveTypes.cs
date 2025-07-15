using System.ComponentModel.DataAnnotations;

namespace EmployeeLeavesManagement.Dto
{
    public class LeaveTypes
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public int MaxDaysAllowed { get; set; }
    }
}

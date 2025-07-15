using System.ComponentModel.DataAnnotations;

namespace EmployeeLeavesManagement.Dto
{
    public class Employee
    {
       
        public int Id { get; set; } 

       
        public String? FirstName { get; set; }

      
        public String? LastName { get; set; }

   
        public String? Email { get; set; }

      
        public String? DateOfJoining { get; set; }

    }
}

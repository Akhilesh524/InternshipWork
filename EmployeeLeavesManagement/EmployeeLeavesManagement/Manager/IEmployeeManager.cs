
using EmployeeLeavesManagement.Dto;
namespace EmployeeLeavesManagement.Manager
{
    public interface IEmployeeManager
    {
        public void createEmployee(Employee employee);

        public List<Employee>Employee();
       
        public Employee? getEmployeeById(int id);

        public void updateEmployeeById(int id, Employee employee);

        public void deleteEmployeeById(int id);
    }


}

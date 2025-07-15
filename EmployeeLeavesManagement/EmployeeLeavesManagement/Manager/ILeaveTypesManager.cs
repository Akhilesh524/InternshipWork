using EmployeeLeavesManagement.Dto;

namespace EmployeeLeavesManagement.Manager
{
    public interface ILeaveTypesManager
    {
        public void createLeaveTypes(LeaveTypes leavetypes);

        public List<LeaveTypes>getAllLeaveTypes();

        public LeaveTypes? getLeaveTypesById(int id);

        public void updateLeaveTypesById(int id, LeaveTypes types);

        public void deleteLeaveTypesById(int id);
    }
}

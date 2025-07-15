using EmployeeLeavesManagement.Dto;

namespace EmployeeLeavesManagement.Manager
{
    public interface ILeaveRequestsManager
    {
        public void createLeaveRequests(LeaveRequests leaverequests);

        public List<LeaveRequests> getAllLeaveRequests();

        public LeaveRequests? getLeaveRequestsById(int id);

        public void updateLeaveRequestsById(int id, LeaveRequests requests);

        public void deleteLeaveRequestsById(int id);
    }
}

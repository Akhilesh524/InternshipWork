using AutoMapper;
using EmployeeLeavesManagement.Dto;
using EmployeeLeavesManagement.Persistence;
using EmployeeLeavesManagement.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace EmployeeLeavesManagement.Manager
{
    public class LeaveRequestsManager : ILeaveRequestsManager
    {

        private readonly EmployeeLeavesDbContext _employeeLeavesDbContext;
        private readonly IMapper _mapper;
        public LeaveRequestsManager(EmployeeLeavesDbContext employeeLeavesDbContext,IMapper mapper)
        {
            _employeeLeavesDbContext = employeeLeavesDbContext;
            _mapper = mapper;
        }

        void ILeaveRequestsManager.createLeaveRequests(LeaveRequests leaverequests)
        {
           

            var leave = _mapper.Map < LeaveRequestsEntity >(leaverequests);
            _employeeLeavesDbContext.LeaveRequests.Add(leave);
            _employeeLeavesDbContext.SaveChanges();
           
        }

     
    

        void ILeaveRequestsManager.updateLeaveRequestsById(int id, LeaveRequests requests)
        {
           var entity = _employeeLeavesDbContext.LeaveRequests.FirstOrDefault(lr=>lr.id ==id);
            if (entity == null) return;

        
            _mapper.Map(requests, entity);

            _employeeLeavesDbContext.SaveChanges();

        }

        void ILeaveRequestsManager.deleteLeaveRequestsById(int id)
        {
          var entity =  _employeeLeavesDbContext.LeaveRequests.FirstOrDefault(lr => lr.id == id);
            _employeeLeavesDbContext.LeaveRequests.Remove(entity);
            _employeeLeavesDbContext.SaveChanges();

        }

        public List<LeaveRequests> getAllLeaveRequests()
        {
            

            var entity = _employeeLeavesDbContext.LeaveRequests.ToList();

            return _mapper.Map<List<LeaveRequests>>(entity);
        }

        public LeaveRequests? getLeaveRequestsById(int id)
        {
            var entity = _employeeLeavesDbContext.LeaveRequests.FirstOrDefault(lr=>lr.id == id);

            if (entity == null) return null;
           

            return _mapper.Map<LeaveRequests>(entity);
           
        }
    }
}

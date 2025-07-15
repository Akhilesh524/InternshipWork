using AutoMapper;
using EmployeeLeavesManagement.Dto;
using EmployeeLeavesManagement.Persistence;
using EmployeeLeavesManagement.Persistence.Entities;

namespace EmployeeLeavesManagement.Manager
{
    public class LeaveTypesManager : ILeaveTypesManager
    {
        private readonly EmployeeLeavesDbContext _employeeLeavesDbContext;
        private readonly IMapper _mapper;
        public LeaveTypesManager(EmployeeLeavesDbContext employeeLeavesDbContext, IMapper mapper)
        {
           _employeeLeavesDbContext = employeeLeavesDbContext;
            _mapper = mapper;
        }

        public List<LeaveTypes> getAllLeaveTypes()
        {
         

            var entity = _employeeLeavesDbContext.LeaveTypes.ToList();
            return _mapper.Map<List<LeaveTypes>>(entity);
        }

        public LeaveTypes? getLeaveTypesById(int id)
        {
            var entity = _employeeLeavesDbContext.LeaveTypes.FirstOrDefault(lt => lt.Id == id);

            if (entity == null) return null;
          

            return _mapper.Map<LeaveTypes>(entity);
        }

        void ILeaveTypesManager.createLeaveTypes(LeaveTypes leavetypes)
        {
           
            var leavestype = _mapper.Map<LeaveTypesEntity>(leavetypes);
            _employeeLeavesDbContext.LeaveTypes.Add(leavestype);
            _employeeLeavesDbContext.SaveChanges();

        }

        void ILeaveTypesManager.deleteLeaveTypesById(int id)
        {
            var entity =_employeeLeavesDbContext.LeaveTypes.FirstOrDefault(lt => lt.Id == id);
            _employeeLeavesDbContext.LeaveTypes.Remove(entity);
            _employeeLeavesDbContext.SaveChanges();
        }

     

     

        void ILeaveTypesManager.updateLeaveTypesById(int id, LeaveTypes types)
        {
           var entity = _employeeLeavesDbContext.LeaveTypes.FirstOrDefault(lt => lt.Id == id);

            if (entity == null) return;
            

            _mapper.Map(types, entity);

            _employeeLeavesDbContext.SaveChanges();
             
        }
    }
}

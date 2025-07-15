using AutoMapper;
using EmployeeLeavesManagement.Dto;
using EmployeeLeavesManagement.Persistence;
using EmployeeLeavesManagement.Persistence.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeLeavesManagement.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly EmployeeLeavesDbContext _employeeLeavesDbContext;
        private readonly IMapper _mapper;
        public EmployeeManager(EmployeeLeavesDbContext employeeLeavesDbContext , IMapper mapper)
        {
            _employeeLeavesDbContext = employeeLeavesDbContext;
            _mapper = mapper;
        }

       void IEmployeeManager.createEmployee(Employee employee)
        {
          
            var entity = _mapper.Map<EmployeeEntity>(employee);
            _employeeLeavesDbContext.Employees.Add(entity);
            _employeeLeavesDbContext.SaveChanges();
        }



        void IEmployeeManager.deleteEmployeeById(int id)
        {
           var entity = _employeeLeavesDbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (entity == null) return;

            _employeeLeavesDbContext.Employees.Remove(entity);
            _employeeLeavesDbContext.SaveChanges();
        }

        void IEmployeeManager.updateEmployeeById(int id, Employee employee)
        {
           var entity = _employeeLeavesDbContext.Employees.FirstOrDefault(e => e.Id == id);
         
            if (entity == null) return;

          
            _mapper.Map(employee, entity);

            _employeeLeavesDbContext.SaveChanges();
        }

        public List<Employee> Employee()
        {
         

            var entity = _employeeLeavesDbContext.Employees.ToList();
            return _mapper.Map<List<Employee>>(entity);


        }

        public Employee? getEmployeeById(int id)
        {

            var entity = _employeeLeavesDbContext.Employees.FirstOrDefault(e => e.Id == id);

            if (entity == null) return null;
          

            return _mapper.Map<Employee>(entity);


        }
    }
}

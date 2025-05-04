using AutoMapper;
using Demo.BusnessLogicLayer.DTO.EmployeeDTO;
using Demo.DataAcessLayer.Data;
using Demo.DataAcessLayer.Data.Repositories.classes;
using Demo.DataAcessLayer.Data.Repositories.interfacies;
using Demo.DataAcessLayer.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.Services.classes
{
    public class EmployeeServices : IEmployeeServices
    {


        
        private readonly IMapper _mapper;
        private readonly AppDBCONTEXT _context;

        public IUnitOfWork UnitOfWork;

        public EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper, AppDBCONTEXT context)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }



        public int CreateEmployee(CreateDEmployeeDTO employee)
        {
            var Employee = _mapper.Map<CreateDEmployeeDTO, Employee>(employee);
             UnitOfWork.EmployeeRepository.Add(Employee);
            return UnitOfWork.savechanges();


        }

        public bool DeleteEmployee(int id)
        {
            var employee = UnitOfWork.EmployeeRepository.GetById(id);
            if (employee == null) return false;
            else
            {
                employee.IsDeleted = true;
               UnitOfWork.EmployeeRepository.Update(employee);
                return UnitOfWork.savechanges() > 0 ? true : false;

            }
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees(bool withtracking)
        {
            var Employees =UnitOfWork.EmployeeRepository.GetAll(withtracking);
            var returnedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(Employees);//auto mapper
            return returnedEmployees;

            //var returnedEmployees = Employees.Select(emp => new EmployeeDTO()
            //{
            //    Id = emp.Id,
            //    Name = emp.Name,
            //    IsActive = emp.IsActive,
            //    Age = emp.Age,
            //    Email = emp.Email,
            //    Salary = emp.Salary,
            //    EmployeeType = emp.employeeType.ToString(),
            //    Gender = emp.gender.ToString()

            //});
            //return returnedEmployees;



        }
        public IEnumerable<EmployeeDTO> GetEmployeesByName(string Name)
        {
            var Employees =UnitOfWork.EmployeeRepository.GetEmployeeByName(Name.ToLower());
            var returnedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(Employees);//auto mapper
            return returnedEmployees;

            }
            public EmployeeDetailsDTO? GetEmployeeById(int id)
        {
            var Employee = UnitOfWork.EmployeeRepository.GetById(id);
            //if (Employee == null) return null;

            //else
            //{
            //    var returnedEmployeeloyees = new EmployeeDetailsDTO()
            //    {
            //        Id = Employee.Id,
            //        Name = Employee.Name,
            //        IsActive = Employee.IsActive,
            //        Age = Employee.Age,
            //        Email = Employee.Email,
            //        Salary = Employee.Salary,
            //        EmployeeType = Employee.employeeType.ToString(),
            //        Gender = Employee.gender.ToString(),
            //        PhoneNumber = Employee.PhoneNumber,
            //        HiringDate = Employee.HiringDate,
            //        CreatedBy = 1,
            //        LastModifiedBy = 1,


            //    };
            //    return returnedEmployeeloyees;
            return Employee == null ? null : _mapper.Map<Employee, EmployeeDetailsDTO>(Employee);

        }

        public int UpdateEmployee(UpdateEmployeeDTO employee)

        {
           UnitOfWork.EmployeeRepository.Update(_mapper.Map<UpdateEmployeeDTO, Employee>(employee));
            return UnitOfWork.savechanges();
        }

    
    }




}
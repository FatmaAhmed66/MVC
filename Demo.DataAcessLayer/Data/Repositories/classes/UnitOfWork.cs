using Demo.DataAcessLayer.Data.Repositories.interfacies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data.Repositories.classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private readonly AppDBCONTEXT _dBCONTEXT;

        public UnitOfWork(IDepartmentRepository departmentRepository,IEmployeeRepository employeeRepository ,AppDBCONTEXT dBCONTEXT)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
           _dBCONTEXT = dBCONTEXT;
        }

     

        IEmployeeRepository IUnitOfWork.EmployeeRepository {

            get
            {
                return _employeeRepository;
            }

            set 
            {
                _employeeRepository = value;
            } 
        }
        IDepartmentRepository IUnitOfWork.DepartmentRepository
        {

            get
            {
                return _departmentRepository;
            }

            set
            {
                _departmentRepository = value;
            }
        }
        public int savechanges()
        {
            return _dBCONTEXT.SaveChanges();

        }
    }
}

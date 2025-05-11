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
        private Lazy<IDepartmentRepository> _departmentRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;
        private readonly AppDBCONTEXT _dBCONTEXT;

        public UnitOfWork(IDepartmentRepository departmentRepository,IEmployeeRepository employeeRepository ,AppDBCONTEXT dBCONTEXT)
        {
            _departmentRepository = new Lazy<IDepartmentRepository>(()=>new DepartmentRepository(dBCONTEXT));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dBCONTEXT));
           _dBCONTEXT = dBCONTEXT;
        }

     

        IEmployeeRepository IUnitOfWork.EmployeeRepository {

            get
            {
                return _employeeRepository .Value;
            }

         
        }
        IDepartmentRepository IUnitOfWork.DepartmentRepository
        {

            get
            {
                return _departmentRepository.Value;
            }

         
        }
        public int savechanges()
        {
            return _dBCONTEXT.SaveChanges();

        }

        //public void Dispose()
        //{
        //    _dBCONTEXT.Dispose();
        //}
    }
}

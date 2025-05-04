using Demo.DataAcessLayer.Data.Repositories.interfacies;
using Demo.DataAcessLayer.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data.Repositories.classes
{

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDBCONTEXT _dBCONTEXT;

        public EmployeeRepository(AppDBCONTEXT dBCONTEXT) : base(dBCONTEXT)
        {
            _dBCONTEXT = dBCONTEXT;
        }

        public override IEnumerable<Employee> GetAll(bool withtracking = false)
        {
            var query = _dBCONTEXT.employees
                                  .Include(e => e.Department)
                                  .Where(e => !e.IsDeleted);

            return withtracking ? query.ToList() : query.AsNoTracking().ToList();
        }

       

        public IQueryable<Employee> GetEmployeeByName(string Name)
        {
            return _dBCONTEXT.employees.Where(E => E.Name.ToLower().Contains(Name));
        }
    }
}


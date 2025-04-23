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

        public EmployeeRepository(AppDBCONTEXT _dBCONTEXT):base(_dBCONTEXT)
        {

        }
        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}

using Demo.DataAcessLayer.Models;
using Demo.DataAcessLayer.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data.Repositories.interfacies
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        

        IQueryable<Employee> GetEmployeeByName(string Name);


    }
}

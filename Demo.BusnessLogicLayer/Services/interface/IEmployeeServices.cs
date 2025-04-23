using Demo.BusnessLogicLayer.DTO.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.Services

{
  public interface IEmployeeServices
  {
        //GET ALL EMPLOYEES
        IEnumerable<EmployeeDTO> GetAllEmployees(bool withtracking =false);

        //GET EMPLOYEE BY ID
        EmployeeDetailsDTO? GetEmployeeById(int id);

        //ADD NEW EMPLOYEE
        int CreateEmployee(CreateDEmployeeDTO employee);

        //UPDATE EMPLOYEE
        int UpdateEmployee(UpdateEmployeeDTO employee);
        //DELETE EMPLOYEE
        bool DeleteEmployee(int id);


  }
}

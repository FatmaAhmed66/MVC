using Demo.DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data.Repositories.interfacies
{
   public interface IDepartmentRepository
    {
        //GET ALL
        IEnumerable<Department> GetAll(bool withtracking = false);

        //GET BY ID
        Department GetById(int id);

        //UPDATE
        int Update(Department Entity);

        //DELETE
        int Delete(Department Enitity);

        //INSERT
        int Add(Department Entity);

    }
}

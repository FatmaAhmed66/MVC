using Demo.DataAcessLayer.Data.Repositories.interfacies;
using Demo.DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data.Repositories.classes
{
    public class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository

    {
        public DepartmentRepository(AppDBCONTEXT _dBCONTEXT):base(_dBCONTEXT)
        {
            
        }

    }
}

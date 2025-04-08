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
    public class DepartmentRepository: IDepartmentRepository
    {

        private  readonly AppDBCONTEXT _dBCONTEXT; //1.using encapsulation
                                                   //intalize =>null

        public DepartmentRepository(AppDBCONTEXT dBCONTEXT)  //ask clr to create object from appdbcontext 
        {                                                    //constructor 
                                                             //this is called dependency injection
            _dBCONTEXT = dBCONTEXT;


            //this isn't used because it make me open the connection i want clr to open connection when user send a request 
            //  dBCONTEXT = new AppDBCONTEXT();//open connection with database

        }
        public int Add(Department Entity)
        {
            _dBCONTEXT.departments.Add(Entity);//added
             return _dBCONTEXT.SaveChanges();//update database

        }

        public int Delete(Department Enitity)
        {
            _dBCONTEXT.departments.Remove(Enitity);
            return _dBCONTEXT.SaveChanges();

        }

        public IEnumerable<Department> GetAll(bool withtracking =false)
        {
            if (withtracking)
            {
                return _dBCONTEXT.departments.ToList();
            }
            else
                return _dBCONTEXT.departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            return _dBCONTEXT.departments.Find(id);

        }

        public int Update(Department Entity)
        {
            _dBCONTEXT.departments.Update(Entity);
            return _dBCONTEXT.SaveChanges();

        }
    }
}

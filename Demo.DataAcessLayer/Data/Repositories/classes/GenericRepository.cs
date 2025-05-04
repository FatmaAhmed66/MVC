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
   

        public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
        {
            private readonly AppDBCONTEXT _dBCONTEXT;

            public GenericRepository(AppDBCONTEXT dBCONTEXT)
            {
                _dBCONTEXT = dBCONTEXT;
            }

        public void Add(T Entity)
        {
            _dBCONTEXT.Set<T>().Add(Entity);
            
        }

        public void Delete(T Enitity)
        {
            _dBCONTEXT.Set<T>().Remove(Enitity);
            
        }

        public virtual IEnumerable<T> GetAll(bool withtracking = false)
        {
            if (withtracking)
            {
                return _dBCONTEXT.Set<T>().Where(E=>E.IsDeleted !=true).ToList();
            }
            else
                return _dBCONTEXT.Set<T>().Where(E => E.IsDeleted != true).AsNoTracking().ToList();
        }

        public virtual T GetById(int id)
        {
            return _dBCONTEXT.Set<T>().Find(id);
        }



        public void Update(T Entity)
        {
            _dBCONTEXT.Set<T>().Update(Entity);
         
        }
    }

    
}

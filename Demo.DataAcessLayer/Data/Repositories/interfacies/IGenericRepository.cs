using Demo.DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAcessLayer.Data.Repositories.interfacies
{
    public interface IGenericRepository<T> where T :BaseEntity  
    {
        //GET ALL
        IEnumerable<T> GetAll(bool withtracking = false);

        //GET BY ID
        T GetById(int id);

        //UPDATE
        void Update(T Entity);

        //DELETE
        void Delete(T Enitity);

        //INSERT
        void Add(T Entity);
    }
}

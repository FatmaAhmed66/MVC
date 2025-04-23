using Demo.DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.DTO
{
     public class DepartmentsDetailsDTO
    {
        //CONSTRUCTOR MAPPING
        //public DepartmentsDetailsDTO(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    Description = department.Description;
        //    Code = department.Code;
        //    CreatedOn = department.CreatedOn;
                 
        //}
        public int Id { get; set; }
        public int CreatedBy { get; set; } //USER ID
        public DateTime CreatedOn { get; set; } //Time of Creation
        public int LastModifiedBy { get; set; } //user id

        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } //soft Delete
    }
}

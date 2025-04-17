using Demo.BusnessLogicLayer.DTO;
using Demo.DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.factories
{
    static public class DepartmentFactory //extention mapping CLASS
    {

        //EXTENSION MAPPING TO GET ALL 
        public static DepartmentDTO ToDepartmentDTO(this Department D)
        {
            return new DepartmentDTO()
            {


                Id = D.Id,
                Name = D.Name,
                Description = D.Description,
                Code = D.Code,
                CreatedOn = D.CreatedOn
              

            };
        }

        public static DepartmentsDetailsDTO ToDepartmentsDetailsDTO(this Department department)
        {
            return new DepartmentsDetailsDTO()
            {

                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                CreatedOn = department.CreatedOn,
                CreatedBy=department.CreatedBy,
                LastModifiedBy=department.LastModifiedBy
            };

        }


        public static Department ToEntity(this CreatedDepartmentDTO departmentDTO)
        {
            return new Department()
            {
                Name = departmentDTO.Name,
                Code = departmentDTO.code,
                Description = departmentDTO.Description,
                CreatedOn = departmentDTO.DateOfCreation
            };
        }

        public static Department ToEntity(this UpdateDepartmentDTO departmentDTO)//overload 
        {
            return new Department()
            {
                Id=departmentDTO.Id,
                Name = departmentDTO.Name,
                Code = departmentDTO.code,
                Description = departmentDTO.Description,
                CreatedOn = departmentDTO.DateOfCreation
            };
        }


    }
}

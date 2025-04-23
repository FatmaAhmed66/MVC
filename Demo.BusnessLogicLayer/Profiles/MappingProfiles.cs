using AutoMapper;
using Demo.BusnessLogicLayer.DTO.EmployeeDTO;
using Demo.DataAcessLayer.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusnessLogicLayer.Profiles
{
   public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDTO>();
             
            CreateMap<Employee, EmployeeDetailsDTO>();
            CreateMap<CreateDEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

        }
    }
}

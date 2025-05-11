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
            CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.EmployeeType,opt => opt.MapFrom(src => src.employeeType.ToString()))
            .ForMember(dest => dest.Gender,opt => opt.MapFrom(src => src.gender.ToString()))
            .ForMember(dest => dest.Department,options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDTO>()

            .ForMember(dest => dest.EmployeeType,
                opt => opt.MapFrom(src => src.employeeType.ToString()))
            .ForMember(dest => dest.Gender,
                opt => opt.MapFrom(src => src.gender.ToString()));
                     


            CreateMap<CreateDEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();


        }
    }
}

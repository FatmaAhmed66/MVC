using Demo.BusnessLogicLayer.DTO;
using Demo.BusnessLogicLayer.factories;
using Demo.DataAcessLayer.Data.Repositories.interfacies;
using Demo.DataAcessLayer.Models;

namespace Demo.BusnessLogicLayer.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            //CLR CREATES THE OBJECT (USE DEPENDENCY INJECTION)
        }


        // GET ALL DEPARTMENTS
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {

            var departments = _departmentRepository.GetAll();

            // 1] MANUAL MAPPING
            //    var departmentsToReturn = departments.Select(D=>new DepartmentDTO
            //    {
            //        Id= D.Id,
            //        Name=D.Name,
            //        Description=D.Description,
            //        Code=D.Code,
            //        CreatedOn=D.CreatedOn


            //    });
            //return departmentsToReturn;

            //2] EXTENSION MAPPING 
            return departments.Select(D => D.ToDepartmentDTO())
                ;

        }

        //GET DEPARTMENT BY ID
        public DepartmentsDetailsDTO GETDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            //1]MANUAL MAPPING

            //if (department is null) return null;
            //else
            //{
            //    var departmentsToReturn = new DepartmentsDetailsDTO()
            //    //{
            //    //    Id = department.Id,
            //    //    Name = department.Name,
            //    //    Description = department.Description,
            //    //    Code = department.Code,
            //    //    CreatedOn = department.CreatedOn,
            //    //    CreatedBy = department.CreatedBy
            //    //};
            //    return departmentsToReturn;

            //}

            //2] EXTENSION MAPPING 
            return department is null ? null : department.ToDepartmentsDetailsDTO();



        }
        //ADD NEW DEPARTMENT 
        public int AddDpartment(CreatedDepartmentDTO departmentDTO)
        {
            var department = departmentDTO.ToEntity();

            return _departmentRepository.Add(department);

        }

        //update department 
        public int UpdateDepartment(UpdateDepartmentDTO departmentDTO)
        {
            var department = departmentDTO.ToEntity();

            return _departmentRepository.Update(department);

        }

        //delete department 
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int result = _departmentRepository.Delete(department);
                return result > 0 ? true : false;

            }
        }
    }
}

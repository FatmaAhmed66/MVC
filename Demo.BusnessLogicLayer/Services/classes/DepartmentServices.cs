using Demo.BusnessLogicLayer.DTO;
using Demo.BusnessLogicLayer.factories;
using Demo.DataAcessLayer.Data.Repositories.interfacies;
using Demo.DataAcessLayer.Models;

namespace Demo.BusnessLogicLayer.Services
{
    public class DepartmentServices : IDepartmentServices 
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IDepartmentRepository departmentRepository,IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
           _unitOfWork = unitOfWork;
            //CLR CREATES THE OBJECT (USE DEPENDENCY INJECTION)
        }


        // GET ALL DEPARTMENTS
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {

            var departments = _unitOfWork.DepartmentRepository.GetAll();

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
            return departments.Select(D => D.ToDepartmentDTO());
                

        }

        //GET DEPARTMENT BY ID
        public DepartmentsDetailsDTO GETDepartmentById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);

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

            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.savechanges();


        }

        //update department 
        public int UpdateDepartment(UpdateDepartmentDTO departmentDTO)
        {
            var department = departmentDTO.ToEntity();

            _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.savechanges();
        }

        //delete department 
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
               _unitOfWork.DepartmentRepository.Delete(department);
                return _unitOfWork.savechanges() > 0 ? true : false;

            }
        }
    }
}

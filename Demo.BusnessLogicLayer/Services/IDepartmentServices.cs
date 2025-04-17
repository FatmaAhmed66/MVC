using Demo.BusnessLogicLayer.DTO;

namespace Demo.BusnessLogicLayer.Services
{
    public interface IDepartmentServices
    {
        int AddDpartment(CreatedDepartmentDTO departmentDTO);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentsDetailsDTO GETDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDTO departmentDTO);
    }
}
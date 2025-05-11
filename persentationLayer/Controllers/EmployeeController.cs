using Demo.BusnessLogicLayer.DTO;
using Demo.BusnessLogicLayer.DTO.EmployeeDTO;
using Demo.BusnessLogicLayer.Services;
using Demo.BusnessLogicLayer.Services.AttachmentServices;
using Demo.DataAcessLayer.Models;
using Demo.DataAcessLayer.Models.EmployeeModel;
using Demo.persentationLayer.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.persentationLayer.Controllers
{
    public class EmployeeController : Controller 
    {

        private readonly IEmployeeServices _employeeService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IDepartmentServices _departmentServices;
        private readonly IAttachmentServices _attachmentServices;

        public EmployeeController(IEmployeeServices employeeService, ILogger<DepartmentController> logger,
                                  IWebHostEnvironment environment,IDepartmentServices departmentServices ,IAttachmentServices attachmentServices)
        {
            _employeeService = employeeService;
            _logger = logger;
            _environment = environment;
            _departmentServices = departmentServices;
            _attachmentServices = attachmentServices;
        }
        
        public IActionResult Index(string? EmployeeSearchName)
        {


            //Binding through view’s dictionary : transfer Data From Action To View
            // 1. ViewData

            //ViewData["Message"] = "Hello ViewData";
            //// 2. ViewBag
            //ViewBag.Message="Hello ViewBag";
            dynamic employee = null;
            if (string.IsNullOrEmpty(EmployeeSearchName))
            {
                 employee = _employeeService.GetAllEmployees();
            }
            else
            {
                employee = _employeeService.GetEmployeesByName(EmployeeSearchName);
            }
            return View(employee);
        }


        #region Create
        [HttpGet]
        public IActionResult Create()
        {


            var departments = _departmentServices.GetAllDepartments(); 
            ViewData["Departments"] = departments;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel _createDEmployeeDTO)
        {
            if (ModelState.IsValid) // Server side validation
            {
                try
                {
                    var employee = new CreateDEmployeeDTO()
                    {
                        Name=_createDEmployeeDTO.Name,
                        IsActive=_createDEmployeeDTO.IsActive,
                        Email=_createDEmployeeDTO.Email,
                        Age=_createDEmployeeDTO.Age,
                        Salary=_createDEmployeeDTO.Salary,
                        Address=_createDEmployeeDTO.Address,
                        Gender=_createDEmployeeDTO.Gender,
                        EmployeeType=_createDEmployeeDTO.EmployeeType,
                        PhoneNumber=_createDEmployeeDTO.PhoneNumber,
                        DepartmentId = _createDEmployeeDTO.DepartmentId,
                        Image=_createDEmployeeDTO.Image,
                        HiringDate = _createDEmployeeDTO.HiringDate,



                    };
                    int result = _employeeService.CreateEmployee(employee);

                    //if (result > 0)
                    //{
                    //    return RedirectToAction(nameof(Index));
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError(string.Empty, "Department can't be created");
                      
                    //}
                }
                catch (Exception ex)
                {


                    if (_environment.IsDevelopment())
                    {
                        // 1. Development => Log Error in Console and return same view with error msg
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        // 2. Deployment => Log Error in file | Table in database And Return Error view
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(_createDEmployeeDTO);

        }
        #endregion

        #region DETAILS
        public IActionResult Details(int ? id)
        {


            if (!id.HasValue) return BadRequest();//400

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee is null) return NotFound();//404
            return View(employee);
        }
        #endregion

        #region EDIT
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();//404

            var employeeDTO = new EmployeeViewModel()
            {

              
                Name = employee.Name,
                Address = employee.Address,
                Gender = Enum.Parse<Gender>(employee.Gender),
                Email=employee.Email,
                Age=employee.Age,
                HiringDate=employee.HiringDate,
                EmployeeType=Enum.Parse<EmployeeType>(employee.EmployeeType),
                IsActive=employee.IsActive,
                PhoneNumber=employee.PhoneNumber,
                DepartmentId = employee.DepartmentId,
                Salary = employee.Salary

            };
            ViewData["Departments"] = _departmentServices.GetAllDepartments();
            

            return View(employeeDTO);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel ViewModel)
        {
            if (!ModelState.IsValid) return View(ViewModel);
            try
            {

                var employee = new UpdateEmployeeDTO()
                {
                    
                    Name = ViewModel.Name,
                    IsActive = ViewModel.IsActive,
                    Email = ViewModel.Email,
                    Age = ViewModel.Age,
                    Salary = ViewModel.Salary,
                    Address = ViewModel.Address,
                    Gender = ViewModel.Gender,
                    EmployeeType = ViewModel.EmployeeType,
                    PhoneNumber = ViewModel.PhoneNumber,
                    HiringDate=ViewModel.HiringDate,
                   
                    



                };


                int result = _employeeService.UpdateEmployee(employee);
                if (result > 0)
                    return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can't be created");

                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error in Console and return same view with error msg
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    // 2. Deployment => Log Error in file | Table in database And Return Error view
                    _logger.LogError(ex.Message);
                }
            }
            return View(ViewModel);

        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _employeeService.DeleteEmployee(id);
                if (deleted)
                {
                    
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Deleted");
                    return RedirectToAction(nameof(Delete), new { id = id });


                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error in Console and return same view with error msg
                    ModelState.AddModelError(string.Empty, ex.Message);
                    
                }
                else
                {
                    // 2. Deployment => Log Error in file | Table in database And Return Error view
                    _logger.LogError(ex.Message);
                    

                }
            }
            return RedirectToAction(nameof(Index));
            #endregion




           
         }

    }
       
    
}

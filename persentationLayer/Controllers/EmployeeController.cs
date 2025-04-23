using Demo.BusnessLogicLayer.DTO;
using Demo.BusnessLogicLayer.DTO.EmployeeDTO;
using Demo.BusnessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.persentationLayer.Controllers
{
    public class EmployeeController : Controller 
    {

        private readonly IEmployeeServices _employeeService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;


        public EmployeeController(IEmployeeServices employeeService, ILogger<DepartmentController> logger,
                                  IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _logger = logger;
            _environment = environment;
        }
        
        public IActionResult Index()
        {
            var employee = _employeeService.GetAllEmployees();

            return View(employee);
        }


        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDEmployeeDTO _createDEmployeeDTO)
        {
            if (ModelState.IsValid) // Server side validation
            {
                try
                {
                    int result = _employeeService.CreateEmployee(_createDEmployeeDTO);

                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be created");
                      
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
            }

            return View(_createDEmployeeDTO);

        }
        #endregion
    }
}

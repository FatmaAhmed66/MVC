using Demo.BusnessLogicLayer.DTO;
using Demo.BusnessLogicLayer.Services;
using Demo.persentationLayer.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace Demo.persentationLayer.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentServices departmentServices,
                                  ILogger<DepartmentController> logger,
                                  IWebHostEnvironment environment)
        {
            _departmentServices = departmentServices;
            _logger = logger;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }


        #region create department
        [HttpGet] //TAKE DATA FROM USER
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost] //RETURN DATA TO DATABASE
        public IActionResult Create(CreatedDepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid) // Server side validation
            {
                try
                {
                    int result = _departmentServices.AddDpartment(departmentDTO);
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

            return View(departmentDTO);
        }
        #endregion


        #region Department Details
        public IActionResult Details (int? id)
        {
            if (!id.HasValue) return BadRequest();//400

            var department = _departmentServices.GETDepartmentById(id.Value);
            if (department is null) return NotFound();//404
            return View(department);
        }
        #endregion

        #region edit of department

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)return BadRequest();//400

                var department = _departmentServices.GETDepartmentById(id.Value);

                if (department is null) return NotFound();//404

            var departmentviewmodel = new DepartmentEditViewModel()
            {
                
                code=department.Code,
                Name=department.Name,
                Description=department.Description,
                DateOfCreation=department.CreatedOn
            };
                return View(departmentviewmodel);

            

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id,DepartmentEditViewModel departmentEditViewModel)
        {
            if (!ModelState.IsValid) return View(departmentEditViewModel);
            try
            {
                var updatedDepartment = new UpdateDepartmentDTO()
                {
                    Id=departmentEditViewModel.Id,
                    code = departmentEditViewModel.code,
                    Name = departmentEditViewModel.Name,
                    Description = departmentEditViewModel.Description,
                    DateOfCreation = departmentEditViewModel.DateOfCreation
                };

                int result = _departmentServices.UpdateDepartment(updatedDepartment);
                if (result > 0)
                    return RedirectToAction(nameof(Index));

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
            return View(departmentEditViewModel);

        }
        #endregion


        #region delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();//400
            var department = _departmentServices.GETDepartmentById(id.Value);

            if (department is null) return NotFound();//404
            return View(department);

        }
        [HttpPost]

        public IActionResult Delete(int id)
        {

            if (id == 0) return BadRequest();
            try
            {
                bool deleted = _departmentServices.DeleteDepartment(id);
                if (deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "department is not Deleted");
                    return RedirectToAction(nameof(Delete), new {id=id});


                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error in Console and return same view with error msg
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // 2. Deployment => Log Error in file | Table in database And Return Error view
                    _logger.LogError(ex.Message);
                    return View("Error");

                }
            }

        }
        #endregion

    }

}

           

using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Employee;
using Nop.Services.Employees;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.EmployeeModel;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers;

[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]

public class EmployeeController : BaseController
{
    private readonly IEmployeeService _employeeService;
    private readonly IPictureService _pictureService;
    private readonly IEmployeeModelFactory _employeeModelFactory;

    public EmployeeController
    (
        IEmployeeService employeeService,
        IPictureService pictureService,
        IEmployeeModelFactory employeeModelFactory
     )
    {
        _employeeService = employeeService;
        _pictureService = pictureService;
        _employeeModelFactory = employeeModelFactory;
    }

   
    public async Task<IActionResult> List()
    {
        var searchModel = await _employeeModelFactory.PrepareEmployeeSearchModelAsync(new EmployeeSearchModel());
        return View("List", searchModel);
    }


    [HttpPost]
    public async Task<IActionResult> List(EmployeeSearchModel searchMode)
    {
        var model = await _employeeModelFactory.PrepareEmployeeListModelAsync(searchMode);
        return Json(model);
    }


    public async Task<IActionResult> Create()
    {
        var model = await _employeeModelFactory.PrepareEmployeeModelAsync(new EmployeeModel(), null);

        return View("Create", model);
    }

    protected virtual async Task UpdatePictureSeoNamesAsync(Employee employee)
    {
        var picture = await _pictureService.GetPictureByIdAsync(employee.PictureId);

        if (picture != null)
            await _pictureService.SetSeoFilenameAsync(picture.Id, await _pictureService.GetPictureSeNameAsync(employee.Name));
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]

    public async Task<IActionResult> Create(EmployeeModel model, bool continueEditing)
    {
        if(ModelState.IsValid)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Designation = model.Designation,
                IsCertified = model.IsCertified,
                Age = model.Age,
                EmployeeStatusId = model.EmployeeStatusId, 
                PictureId = model.PictureId   
            };

            await _employeeService.InsertEmployeeAsync(employee);
            await UpdatePictureSeoNamesAsync(employee);

            return continueEditing ? RedirectToAction("Edit", new { id = employee.Id }) : RedirectToAction("List");
        }

        model = await _employeeModelFactory.PrepareEmployeeModelAsync(model, null);

        return View("Create", model);
    }



    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id); 

        if(employee == null) 
            return RedirectToAction("List");

        var model = await _employeeModelFactory.PrepareEmployeeModelAsync(null, employee);

        return View("Edit", model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]

    public async Task<IActionResult> Edit(EmployeeModel model, bool continueEditing)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(model.Id);
        if(employee==null)
            return RedirectToAction("List");
        if(ModelState.IsValid)
        {
            employee.Name = model.Name;
            employee.Designation = model.Designation;
            employee.IsCertified = model.IsCertified;
            employee.Age = model.Age;
            employee.PictureId = model.PictureId;
            employee.EmployeeStatusId = model.EmployeeStatusId;
           
            await _employeeService.UpdateEmployeeAsync(employee);
            return continueEditing ? RedirectToAction("Edit", new { id = employee.Id }) : RedirectToAction("List");
        }

        model  = await _employeeModelFactory.PrepareEmployeeModelAsync(model, employee);
        return View("Edit", model);
    }



    [HttpPost]
    public async Task<IActionResult> Delete(EmployeeModel model)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(model.Id);

        if (employee == null)
            return RedirectToAction("List");

        await _employeeService.DeleteEmployeeAsync (employee);
        return RedirectToAction("List");
    }
}

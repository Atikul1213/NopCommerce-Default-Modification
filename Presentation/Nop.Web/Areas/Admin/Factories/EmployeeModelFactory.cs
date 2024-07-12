using Nop.Core.Domain.Employee;
using Nop.Services;
using Nop.Services.Employees;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Areas.Admin.Models.EmployeeModel;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories;

public class EmployeeModelFactory : IEmployeeModelFactory
{

    private readonly IEmployeeService _employeeService;
    private readonly ILocalizationService _localizationService;
    private readonly IPictureService _pictureService;

    public EmployeeModelFactory
    (
        IEmployeeService employeeService,
        ILocalizationService localizationService,
        IPictureService pictureService

    )
    {
        _employeeService = employeeService;
        _localizationService = localizationService;
        _pictureService = pictureService;   
    }


    public async Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel)
    {

        ArgumentNullException.ThrowIfNull(nameof(searchModel));
        var employees = await _employeeService.SearchEmployeeAsync(searchModel.Name, searchModel.EmployeeStatusId,
                                pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize
                                );
        var model = await new EmployeeListModel().PrepareToGridAsync(searchModel, employees, () =>
        {
            return employees.SelectAwait(async employee =>
            {

                return await PrepareEmployeeModelAsync(null, employee, true);
            });
        });

        return model;

    }


    public async Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, Employee employee, bool excludeProperties = false)
    {
         

        if(employee !=null)
        {
            if(model == null)
            {
                model = new EmployeeModel()
                {
                    Name = employee.Name,
                    Designation = employee.Designation,
                    Age = employee.Age,
                    IsCertified = employee.IsCertified,
                    PictureId = employee.PictureId,
                    Id = employee.Id,
                    EmployeeStatusId = employee.EmployeeStatusId,
                    EmployeeStatusStr = await _localizationService.GetLocalizedEnumAsync(employee.EmployeeStatus)
                };

                var picture = await _pictureService.GetPictureByIdAsync(employee.Id);

                (model.PictureThumbnailUrl, _) = await _pictureService.GetPictureUrlAsync(picture, 75); 

                model.EmployeeStatusStr = await _localizationService.GetLocalizedEnumAsync(employee.EmployeeStatus); 
            }
        }

        if (!excludeProperties)
            model.AvailableEmployeeStatusOptions = (await EmployeeStatus.Active.ToSelectListAsync()).ToList();

        return model;
    }




    public async Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel)
    {
        

        ArgumentNullException.ThrowIfNull(nameof(searchModel));

        searchModel.AvailableEmployeeStatusOptions = (await EmployeeStatus.Active.ToSelectListAsync()).ToList();

        searchModel.AvailableEmployeeStatusOptions.Insert(0,
        new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
        {
            Text = "All",
            Value = "0"
        });

        searchModel.SetGridPageSize();
        return searchModel;


    }
}

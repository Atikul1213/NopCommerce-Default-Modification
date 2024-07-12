using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.EmployeeModel;

public record EmployeeSearchModel : BaseSearchModel
{
    public EmployeeSearchModel()
    {
        AvailableEmployeeStatusOptions = new List<SelectListItem>();
    }

    [NopResourceDisplayName("Area.Admin.Model.Employee.List.Name")]
    public string Name { get; set; }
    [NopResourceDisplayName("Area.Admin.Model.Employee.List.EmployeeStatus")]
    public int EmployeeStatusId { get; set; }
    public IList<SelectListItem> AvailableEmployeeStatusOptions { get; set; }
}

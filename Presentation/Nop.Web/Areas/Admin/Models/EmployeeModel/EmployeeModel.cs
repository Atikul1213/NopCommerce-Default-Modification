using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.EmployeeModel;

public record EmployeeModel : BaseNopEntityModel
{
    public EmployeeModel()
    {
        AvailableEmployeeStatusOptions = new List<SelectListItem>();
    }
    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.Designation")]
    public string Designation { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.Age")]
    public int Age { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.IsCertified")]
    public bool IsCertified { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.EmployeeStatus")]
    public int EmployeeStatusId { get; set; }

    [UIHint("Picture")]
    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.Picture")]
    public int PictureId { get; set; }

    
    public string PictureThumbnailUrl { get; set; }

    [NopResourceDisplayName("Areas.Admin.Model.Employee.Fields.EmployeeStatus")]
    public string EmployeeStatusStr { get; set; }

    public IList<SelectListItem> AvailableEmployeeStatusOptions { get; set; }

}

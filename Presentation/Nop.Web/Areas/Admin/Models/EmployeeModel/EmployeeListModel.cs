using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.EmployeeModel;

public record EmployeeListModel : BasePagedListModel<EmployeeModel>
{
    public string Name { get; set; }
}

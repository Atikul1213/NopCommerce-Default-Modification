using Nop.Web.Areas.Admin.Models.EmployeeModel;

using Nop.Core.Domain.Employee;
namespace Nop.Web.Areas.Admin.Factories;

public interface IEmployeeModelFactory
{
    Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel);
    Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel);
    Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, Employee employee, bool excludeProperties = false);
}

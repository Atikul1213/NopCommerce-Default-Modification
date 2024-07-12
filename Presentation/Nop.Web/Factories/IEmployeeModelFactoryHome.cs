using Nop.Core.Domain.Employee;
using Nop.Web.Models.EmployeeModelHome;

namespace Nop.Web.Factories;

public interface IEmployeeModelFactoryHome
{
    Task<EmployeeModelHome> PrepareEmployeeModeHomeAsync(Employee employee);
    Task<IList<EmployeeModelHome>> PrepareEmployeeModelListHomeAsync(IList<Employee> employee);
}

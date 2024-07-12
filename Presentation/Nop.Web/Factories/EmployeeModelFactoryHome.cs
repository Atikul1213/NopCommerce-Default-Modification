using Nop.Core.Domain.Employee;
using Nop.Web.Models.EmployeeModelHome;

namespace Nop.Web.Factories;

public class EmployeeModelFactoryHome : IEmployeeModelFactoryHome
{
    public Task<EmployeeModelHome> PrepareEmployeeModeHomeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task<IList<EmployeeModelHome>> PrepareEmployeeModelListHomeAsync(IList<Employee> employee)
    {
        throw new NotImplementedException();
    }
}

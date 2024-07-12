using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Employee;
namespace Nop.Services.Employees;

public interface IEmployeeService
{

    Task InsertEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(Employee employee);

    Task<Employee> GetEmployeeByIdAsync(int id);

    Task<IPagedList<Employee> > SearchEmployeeAsync(string name,int statusId,int pageIndex = 0, int pageSize = int.MaxValue); 

    


}

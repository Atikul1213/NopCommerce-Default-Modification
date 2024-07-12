using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Employee;
using Nop.Data;

namespace Nop.Services.Employees;
public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employeeRepo;
    public EmployeeService(IRepository<Employee>employeeRepository)
    {
        _employeeRepo = employeeRepository;
    }

    public virtual async Task DeleteEmployeeAsync(Employee employee)
    {
        await _employeeRepo.DeleteAsync(employee);
    }

    public virtual async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _employeeRepo.GetByIdAsync(id);
    }

    public virtual async Task InsertEmployeeAsync(Employee employee)
    {
        await _employeeRepo.InsertAsync(employee);
    }

    public virtual async Task<IPagedList<Employee> > SearchEmployeeAsync(string name, int statusId, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = from e in _employeeRepo.Table
                    select e;
                     
                  

        if (!string.IsNullOrEmpty(name))
            query = query.Where(e => e.Name.Contains(name));
        if (statusId > 0)
            query = query.Where(e => e.EmployeeStatusId == statusId);
        query = query.OrderBy(e => e.Name);
        return await query.ToPagedListAsync(pageIndex, pageSize);
    }

    public virtual async Task UpdateEmployeeAsync(Employee employee)
    {
        await _employeeRepo.UpdateAsync(employee);
    }
}

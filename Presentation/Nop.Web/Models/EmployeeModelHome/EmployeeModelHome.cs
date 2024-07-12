using Nop.Core.Domain.Employee;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Media;

namespace Nop.Web.Models.EmployeeModelHome;

public record EmployeeModelHome : BaseNopEntityModel
{
    public EmployeeModelHome()
    {
        Picture = new PictureModel();
    }
    public string Name { get; set; }
    public PictureModel Picture { get; set; }
    public bool IsCertified { get; set; }
    public int Age { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; }
    public string EmployeeStatusStr { get; set; }
    public string Designation { get; set; }
    
}

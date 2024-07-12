using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.EmployeeModel;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Validators.Employee;

public class EmployeeValidator : BaseNopValidator<EmployeeModel>
{

    public EmployeeValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Areas.Admin.Model.Employee.Fields.Name.Required"));
        RuleFor(x=>x.Designation).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Areas.Admin.Model.Employee.Fields.Designation.Required"));
    }
}

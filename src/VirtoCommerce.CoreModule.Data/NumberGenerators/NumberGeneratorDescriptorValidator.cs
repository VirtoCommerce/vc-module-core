using FluentValidation;
using VirtoCommerce.CoreModule.Core.NumberGenerators;

namespace VirtoCommerce.CoreModule.Data.NumberGenerators
{
    public class NumberGeneratorDescriptorValidator : AbstractValidator<NumberGeneratorDescriptor>
    {
        public NumberGeneratorDescriptorValidator()
        {
            RuleFor(x => x.TargetType).NotEmpty();
            RuleFor(x => x.Template).NotEmpty().Must(str => str.Contains("{0") || str.Contains("{1"));
            RuleFor(x => x.TenantId).NotEmpty();
            RuleFor(x => x.Increment).NotEqual(0).When(x => x.IsActive);
        }
    }
}

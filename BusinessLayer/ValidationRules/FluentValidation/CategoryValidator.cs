using EntityLayer.DTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryForHomeDto>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kateqoriya adı boş keçilə bilməz");
        }
    }
}

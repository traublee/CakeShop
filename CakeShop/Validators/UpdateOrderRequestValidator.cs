using FluentValidation;
using CakeShop.Models.Requests;

namespace CakeShop.Models.Validators
{
    public class UpdateOrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}   
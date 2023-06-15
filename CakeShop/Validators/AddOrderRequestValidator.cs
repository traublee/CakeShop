using FluentValidation;
using CakeShop.Models.Requests;

namespace CakeShop.Models.Validators
{
    public class AddOrderRequestValidator : AbstractValidator<OrderRequest>
    {
        public AddOrderRequestValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.TotalAmount).NotEmpty();
        }
    }
}
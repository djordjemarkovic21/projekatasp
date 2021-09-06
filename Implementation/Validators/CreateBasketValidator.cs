using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateBasketValidator : AbstractValidator<BasketDto>
    {
        public CreateBasketValidator(Context context)
        {
            RuleFor(x => x.IdPrice).NotEmpty().WithMessage("You have to choose Price").Must(x => context.Prices.Any(p => p.Id == x)).WithMessage("Price not exists");

            RuleFor(x => x.PassengersNumber).NotEmpty().WithMessage("You have to choose number of passengers").Must(x => x>=1).WithMessage("Minimum numer of passenger is 1");

            RuleFor(x => x.IdUser).Must(x => context.Users.Any(u => u.Id == x)).WithMessage("User not exists");
        }
    }
}

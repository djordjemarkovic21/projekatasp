using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class DestinationValidator : AbstractValidator<DestinationDto>
    {
        public DestinationValidator(Context context)
        {
            RuleFor(x => x.IdFrom).NotEmpty().WithMessage("You have to choose City from").Must(x => context.Cities.Any(city => city.Id == x)).WithMessage("City from not exists");

            RuleFor(x => x.IdTo).NotEmpty().WithMessage("You have to choose City To").Must(x => context.Cities.Any(city => city.Id == x)).WithMessage("City to not exists");

            RuleFor(x => x.Duration).NotEmpty().WithMessage("You have to choose Duration").Must(x => x>0).WithMessage("Duration has to be greater than 0");
        }
    }
}

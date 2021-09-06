using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateTimetableValidator : AbstractValidator<TimetableDto>
    {
        public CreateTimetableValidator(Context context)
        {
            RuleFor(x => x.IdDestination).NotEmpty().WithMessage("You have to choose Destination").Must(x => context.Destinations.Any(d => d.Id == x)).WithMessage("Destination not exists");

            RuleFor(x => x.DepartureDate).NotEmpty().WithMessage("You have to choose Departure date").Must(x => x>DateTime.Now).WithMessage("Chose date in future");

            RuleFor(x => x.Price).NotEmpty().WithMessage("You have to enter price");
        }
    }
}

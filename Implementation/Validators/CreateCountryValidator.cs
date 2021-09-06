using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateCountryValidator : AbstractValidator<CountryDto>
    {
        public CreateCountryValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You have to choose Country Name")
                .Must(name=> !context.Countries.Any(x => x.Name == name)).WithMessage(dto => $"Country with {dto.Name} already exists");
        }
    }
}

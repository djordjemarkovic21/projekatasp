using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateCountryValidator : AbstractValidator<CountryDto>
    {
        public UpdateCountryValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You have to choose Country Name");

            RuleFor(x => x.Name).Must((dto, name) => !context.Countries.Any(y => y.Name == name && y.Id != dto.Id))
                 .WithMessage(dto => $"Country {dto.Name} already exists.");
        }
    }
}

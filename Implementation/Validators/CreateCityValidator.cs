using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateCityValidator : AbstractValidator<CityDto>
    {
        public CreateCityValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You have to choose City Name")
                .Must(name => !context.Cities.Any(x => x.Name == name)).WithMessage(dto => $"City with {dto.Name} already exists");

            RuleFor(x => x.IdCountry).NotEmpty().WithMessage("You have to choose Country").Must(x => context.Countries.Any(country => country.Id == x)).WithMessage("Country not exists");
        }
    }
}

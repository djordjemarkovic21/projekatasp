using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateCityValidator : AbstractValidator<CityDto>
    {
        public UpdateCityValidator(Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You have to choose City Name");

            RuleFor(x => x.Name).Must((dto, name) => !context.Cities.Any(y => y.Name == name && y.Id != dto.Id))
                 .WithMessage(dto => $"City {dto.Name} already exists.");

            RuleFor(x => x.IdCountry).NotEmpty().WithMessage("You have to choose Country").Must(x => context.Countries.Any(country => country.Id == x)).WithMessage("Country not exists");
        }
    }
}

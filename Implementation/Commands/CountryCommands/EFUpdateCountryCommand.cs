using Application.Commands.CountryCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.CountryCommands
{
    public class EFUpdateCountryCommand : IUpdateCountryCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UpdateCountryValidator _validator;

        public EFUpdateCountryCommand(Context context, IMapper mapper, UpdateCountryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        //validator

        public int Id => 27;

        public string Name => "Update country";

        public void Execute(CountryDto request)
        {
            var country = _context.Countries.Find(request.Id);

            if (country == null)
            {
                throw new EntityNotFoundException(request.Id.Value, typeof(Country));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, country);
            _context.SaveChanges();
        }
    }
}

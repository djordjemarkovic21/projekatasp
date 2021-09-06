using Application.Commands.CountryCommands;
using Application.DataTransfer;
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
    public class EFCreateCountryCommand : ICreateCountryCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UpdateCountryValidator _validator;

        public EFCreateCountryCommand(Context context, IMapper mapper, UpdateCountryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }


        public int Id => 24;

        public string Name => "Create country";

        public void Execute(CountryDto request)
        {
           _validator.ValidateAndThrow(request);
            ///
            _context.Countries.Add(_mapper.Map<Country>(request));
            _context.SaveChanges();
        }
    }
}

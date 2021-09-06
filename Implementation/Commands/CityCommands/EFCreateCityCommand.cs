using Application.Commands.CityCommand;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.CityCommands
{
    public class EFCreateCityCommand : ICreateCityCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateCityValidator _validator;


        public EFCreateCityCommand(Context context, IMapper mapper, CreateCityValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        /// dodati validator

        public int Id => 21;

        public string Name => "Create city";

        public void Execute(CityDto request)
        {
            _validator.ValidateAndThrow(request);
            
            _context.Cities.Add(_mapper.Map<City>(request));
            _context.SaveChanges();
        }
    }
}

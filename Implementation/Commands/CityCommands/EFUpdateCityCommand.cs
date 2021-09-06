using Application.Commands.CityCommand;
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

namespace Implementation.Commands.CityCommands
{
    public class EFUpdateCityCommand : IUpdateCityCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UpdateCityValidator _validator;
        //validacija

        public EFUpdateCityCommand(Context context, IMapper mapper, UpdateCityValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Update city";

        public void Execute(CityDto request)
        {
            var city = _context.Cities.Find(request.Id);

            if (city == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(City));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, city);
            _context.SaveChanges();
        }
    }
}

using Application.Commands.DestinationCommand;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.DesinationCommands
{
    public class EFCreateDestinationCommand : ICreateDestinationCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly DestinationValidator _validator;

        public EFCreateDestinationCommand(Context context, IMapper mapper, DestinationValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }


        public int Id => 42;

        public string Name => "Create destination";

        public void Execute(DestinationDto request)
        {
            _validator.ValidateAndThrow(request);
            

            _context.Destinations.Add(_mapper.Map<Destination>(request));
            _context.SaveChanges();
        }
    }
}

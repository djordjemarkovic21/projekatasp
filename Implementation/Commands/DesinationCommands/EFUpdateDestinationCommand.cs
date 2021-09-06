using Application.Commands.DestinationCommand;
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

namespace Implementation.Commands.DesinationCommands
{
    public class EFUpdateDestinationCommand : IUpdateDestinationCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly DestinationValidator _validator;

        public EFUpdateDestinationCommand(Context context, IMapper mapper, DestinationValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }



        public int Id => 28;

        public string Name => "Update destination";

        public void Execute(DestinationDto request)
        {
            var destination = _context.Destinations.Find(request.Id);

            if (destination == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Destination));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, destination);
            _context.SaveChanges();
        }
    }
}

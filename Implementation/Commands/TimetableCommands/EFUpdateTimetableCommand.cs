using Application.Commands.TimetableCommands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands.TimetableCommands
{
    public class EFUpdateTimetableCommand : IUpdateTimetableCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateTimetableValidator _validator;

        public EFUpdateTimetableCommand(Context context, IMapper mapper, CreateTimetableValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }



        public int Id => 31;

        public string Name => "Update timetable";

        public void Execute(TimetableDto request)
        {
            var timetable = _context.Timetables.Find(request.Id);

            if (timetable == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Timetable));
            }

             _validator.ValidateAndThrow(request);
            if (request.Price != timetable.Prices.OrderByDescending(p => p.CreatedAt).Select(p => p.PriceValue).FirstOrDefault())
            {
                _context.Prices.Add(new Price
                {
                    Timetable = timetable,
                    PriceValue = request.Price
                });
            }

            _mapper.Map(request, timetable);
            _context.SaveChanges();
        }
    }
}

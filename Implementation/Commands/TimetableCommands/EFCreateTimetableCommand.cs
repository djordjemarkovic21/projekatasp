using Application.Commands.TimetableCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.TimetableCommands
{
    public class EFCreateTimetableCommand : ICreateTimetableCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateTimetableValidator _validator;

        public EFCreateTimetableCommand(Context context, IMapper mapper, CreateTimetableValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        //validacija


        public int Id => 30;

        public string Name => "Create timetable";

        public void Execute(TimetableDto request)
        {
            _validator.ValidateAndThrow(request);

            var timetable = _mapper.Map<Timetable>(request);

            _context.Prices.Add(new Price
            {
                Timetable = timetable,
                PriceValue = request.Price,
                DateFrom=DateTime.Now
            });


            _context.Timetables.Add(timetable);
            _context.SaveChanges();


        }
    }
}

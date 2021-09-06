using Application.Commands.BasketCommands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domen;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Basket
{
    public class EFCreateBasketCommand : ICreateBasketCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateBasketValidator _validator;

        public EFCreateBasketCommand(Context context, IMapper mapper, CreateBasketValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Create basket";

        public void Execute(BasketDto request)
        {
            _validator.ValidateAndThrow(request);
            
            request.ReservationDate = DateTime.Now;
            _context.Baskets.Add(_mapper.Map<Domen.Basket>(request));
            _context.SaveChanges();
        }
    }
}

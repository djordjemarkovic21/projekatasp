using Application.Commands.BasketCommands;
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

namespace Implementation.Commands.Basket
{
    public class EFUpdateBasketCommand : IUpdateBasketCommand
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly CreateBasketValidator _validator;

        public EFUpdateBasketCommand(Context context, IMapper mapper, CreateBasketValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Update basket";

        public void Execute(BasketDto request)
        {
            var basket = _context.Baskets.Find(request.Id);

            if (basket == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Domen.Basket));
            }

             _validator.ValidateAndThrow(request);

            _mapper.Map(request, basket);
            _context.SaveChanges();
        }
    }
}

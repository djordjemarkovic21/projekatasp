using Application.Commands.BasketCommands;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.Basket
{
    public class EFDeleteBasketCommand : IDeleteBasketCommand
    {
        private readonly Context _context;

        public EFDeleteBasketCommand(Context context)
        {
            _context = context;
        }

        public int Id => 14;

        public string Name => "Delete basket";

        public void Execute(int request)
        {
            var basket = _context.Baskets.Find(request);

            if (basket == null)
            {
                throw new EntityNotFoundException(request, typeof(Domen.Basket));
            }

            basket.IsActive = false;
            basket.IsDeleted = true;
            basket.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}

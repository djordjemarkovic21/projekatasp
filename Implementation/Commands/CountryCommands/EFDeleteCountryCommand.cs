using Application.Commands.CountryCommands;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.CountryCommands
{
    public class EFDeleteCountryCommand : IDeleteCountryCommand
    {
        private readonly Context _context;

        public EFDeleteCountryCommand(Context context)
        {
            _context = context;
        }

        public int Id => 26;

        public string Name => "Delete country";

        public void Execute(int request)
        {
            var country = _context.Countries.Find(request);

            if (country == null)
            {
                throw new EntityNotFoundException(request, typeof(Country));
            }

            country.IsActive = false;
            country.IsDeleted = true;
            country.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}

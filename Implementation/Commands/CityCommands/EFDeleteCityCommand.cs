using Application.Commands.CityCommand;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.CityCommands
{
    public class EFDeleteCityCommand : IDeleteCityCommand
    {
        private readonly Context _context;

        public EFDeleteCityCommand(Context context)
        {
            _context = context;
        }

        public int Id => 23;

        public string Name => "Delete city";

        public void Execute(int request)
        {
            var city = _context.Cities.Find(request);

            if (city == null)
            {
                throw new EntityNotFoundException(request, typeof(City));
            }

            city.IsActive = false;
            city.IsDeleted = true;
            city.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}

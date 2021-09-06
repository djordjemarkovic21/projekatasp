using Application.Commands.DestinationCommand;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.DesinationCommands
{
    public class EFDeleteDestinationCommand : IDeleteDestinationCommand
    {
        private readonly Context _context;

        public EFDeleteDestinationCommand(Context context)
        {
            _context = context;
        }

        public int Id => 29;

        public string Name => "Delete destination";

        public void Execute(int request)
        {
            var destination = _context.Destinations.Find(request);

            if (destination == null)
            {
                throw new EntityNotFoundException(request, typeof(Destination));
            }

            destination.IsActive = false;
            destination.IsDeleted = true;
            destination.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}

using Application.Commands.TimetableCommands;
using Application.Exceptions;
using DataAccess;
using Domen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands.TimetableCommands
{
    public class EFDeleteTimetableCommand : IDeleteTimetableCommand
    {
        private readonly Context _context;

        public EFDeleteTimetableCommand(Context context)
        {
            _context = context;
        }

        public int Id => 32;

        public string Name => "Delete timetable";

        public void Execute(int request)
        {
            var timetable = _context.Timetables.Find(request);

            if (timetable == null)
            {
                throw new EntityNotFoundException(request, typeof(Timetable));
            }

            timetable.IsActive = false;
            timetable.IsDeleted = true;
            timetable.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}

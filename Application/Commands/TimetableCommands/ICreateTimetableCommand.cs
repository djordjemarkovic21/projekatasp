﻿using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.TimetableCommands
{
    public interface ICreateTimetableCommand : ICommand<TimetableDto>
    {
    }
}

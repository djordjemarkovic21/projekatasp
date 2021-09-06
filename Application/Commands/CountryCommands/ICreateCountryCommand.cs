using Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CountryCommands
{
    public interface ICreateCountryCommand : ICommand<CountryDto>
    {
    }
}

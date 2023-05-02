using MediatR;
using Onion.RentACar.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.RentACar.Application.Features.CQRS.Commands.CarCommands
{
    public class CreateCarCommandRequest : IRequest<CarCreatedDto?>
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Class { get; set; }
        public string? Age { get; set; }
        public int Price { get; set; }
    }
}

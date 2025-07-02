using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommands:IRequest<Unit>
    {
        public string? userId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
    }
}

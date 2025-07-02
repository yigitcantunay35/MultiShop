using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandler
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommands,Unit>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository) => _repository = repository;

        public async Task<Unit> Handle(CreateOrderingCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering 
            {
                OrderTime = request.OrderTime,
                TotalPrice = request.TotalPrice,
                userId = request.userId,
            });

            return Unit.Value;
        }
    }
}

using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommands commmand)
        {
            var values = await _repository.GetByIdAsync(commmand.OrderDetailId);
            values.ProductId = commmand.ProductId;
            values.ProductName = commmand.ProductName;
            values.ProductPrice = commmand.ProductPrice;
            values.ProductAmount = commmand.ProductAmount;
            values.ProductTotalPrice = commmand.ProductTotalPrice;
            values.OrderDetailId = commmand.OrderDetailId;
            await _repository.UpdateAsync(values);
        }
    }
}

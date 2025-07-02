using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)                                                                         
        {
            var values = await _repository.GetByIdAsync(query.OrderDetailId);
            return new GetOrderDetailByIdQueryResult
            {
               OrderDetailId = values.OrderDetailId,
               ProductId = values.ProductId,
               ProductName = values.ProductName,
               ProductAmount = values.ProductAmount,
               ProductPrice = values.ProductPrice,
               ProductTotalPrice = values.ProductTotalPrice,
               OrderingId = values.OrderingId,
            };


        }
    }
}

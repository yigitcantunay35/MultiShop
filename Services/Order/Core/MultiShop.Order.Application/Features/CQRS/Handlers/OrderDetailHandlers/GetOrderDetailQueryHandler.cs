﻿using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle() 
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult 
            {
                OrderDetailId = x.OrderDetailId,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductAmount = x.ProductAmount,
                ProductTotalPrice = x.ProductTotalPrice,
                OrderingId = x.OrderingId
            }).ToList();
        
        }
    }
}

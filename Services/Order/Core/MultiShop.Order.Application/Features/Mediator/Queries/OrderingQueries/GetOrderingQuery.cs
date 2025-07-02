﻿using MediatR;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.Features.Mediator.Result.OrderingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    //Bunun ise bir liste dönmesidir.
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
    {
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public int OrderDetailId { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            OrderDetailId = id;
        }
    }
}

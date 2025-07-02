using MediatR;
using MultiShop.Order.Application.Features.Mediator.Result.OrderingResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    //Şimdi diğerinle arasındaki fark ise bunun id'ye göre bir dönmesi
    public class GetOrderingByIdQuery:IRequest<GetOrderingByIdQueryResult>
    {
        public int OrderingId { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            OrderingId = id;
        }
    }
}

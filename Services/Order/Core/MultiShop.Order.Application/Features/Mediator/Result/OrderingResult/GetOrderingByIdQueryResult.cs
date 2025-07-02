using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Result.OrderingResult
{
    public class GetOrderingByIdQueryResult
    {
        public int OrderingId { get; set; }
        public string? userId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }
    }
}

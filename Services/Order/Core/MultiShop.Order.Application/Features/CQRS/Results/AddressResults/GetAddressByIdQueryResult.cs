using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressByIdQueryResult
    {
        //Burada id'ye göre getirme var ve hepsinin yazmamıızn sebebi ise id'ye göre getirilen bütün entityler gelecek ondan. "select  * from where id='id'" yapar Burada listelemeye ihtiyaç duyulur.
        public int AddressId { get; set; }
        public string? UserId { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Detail { get; set; }
    }
}

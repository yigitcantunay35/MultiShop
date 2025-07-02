using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressQueryResult
    {
        //Burada ise hepsi yazdık çünkü gel all yani bütün herşeyi getir dedik. "select  * from" yapar
        public int AddressId { get; set; }
        public string? UserId { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Detail { get; set; }
    }
}

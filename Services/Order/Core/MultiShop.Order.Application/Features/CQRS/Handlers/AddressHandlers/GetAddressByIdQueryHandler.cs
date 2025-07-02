using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query) //Burada "GetAddressByIdQueryResult"
            //Bunu kullandık çünkü bir getirme işlemi yapılıyor.
        {
            var values = await _repository.GetByIdAsync(query.AddressId);
            return new GetAddressByIdQueryResult 
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId,
            };
            //Burada Result altındaki sınıfları kullandık "GetAddressByIdQueryResult" bunu yani.
            //Buradakiler yani handlers altındaki sınıfları result altındakiler ile eşitledik.

        }
    }
}

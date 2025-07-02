using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommands commmand) 
        {
            var values = await _repository.GetByIdAsync(commmand.AddressId);
            values.Detail = commmand.Detail;
            values.District = commmand.District;
            values.City = commmand.City;
            values.UserId = commmand.UserId;
            await _repository.UpdateAsync(values);
        
        }
    }
}

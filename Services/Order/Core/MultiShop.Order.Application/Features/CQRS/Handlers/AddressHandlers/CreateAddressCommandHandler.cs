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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        //Burada sadece bir metodun bir işlem yapması için böyle tanımlanır ve SOLID prensiplerini ezmeyelim.
        public async Task Handle(CreateAddressCommands createAddressCommand) 
        {
            await _repository.CreateAsync(new Address 
            {
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
            });
        //Mapleme işlemi olmadığı için bu şekilde yapıldı.
        }
    }
}

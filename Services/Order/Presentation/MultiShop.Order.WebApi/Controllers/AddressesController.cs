using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _context;
        private readonly GetAddressByIdQueryHandler _contextById;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler context, GetAddressByIdQueryHandler contextById, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _context = context;
            _contextById = contextById;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _context.Handle();
            return Ok(values);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> AddressGetById(int id)
        {
            var values = await _contextById.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommands command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Ekleme İşlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommands command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarıyla gerçekleşti");
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommands(id));
            return Ok("Silme işlemi başarılı");

        }


    }
}

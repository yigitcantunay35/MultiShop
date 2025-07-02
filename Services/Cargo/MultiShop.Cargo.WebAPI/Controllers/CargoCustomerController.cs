using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDto;
using Microsoft.AspNetCore.Authorization;


namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {

        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult ListCargoCustomer()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            
            CargoCustomer Cargocustomer = new CargoCustomer 
            {   
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Phone = createCargoCustomerDto.Phone,
                Email = createCargoCustomerDto.Email,
                Surname = createCargoCustomerDto.Surname,
                Name = createCargoCustomerDto.Name,
            };
            _cargoCustomerService.TInsert(Cargocustomer);
            return Ok("Kargo müşteri ekleme başarılı");
            //Burada sadece istediğimiz parametre veri girişi olarak olsun diye yaptık.
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşteri başarıyla Silindi.");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByIdCargoCustomer(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer Cargocustomer2 = new CargoCustomer
            {
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Phone = updateCargoCustomerDto.Phone,
                Email = updateCargoCustomerDto.Email,
                Surname = updateCargoCustomerDto.Surname,
                Name = updateCargoCustomerDto.Name,
            };
            _cargoCustomerService.TUpdate(Cargocustomer2);
            return Ok("Kargo Müşteri  başarıyla güncellendi.");
        }



    }
}

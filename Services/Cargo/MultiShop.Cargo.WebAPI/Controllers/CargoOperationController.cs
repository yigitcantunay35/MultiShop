using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;

        public CargoOperationController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }

        [HttpGet]
        public IActionResult ListCargoOperation()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {

            CargoOperation CargoOperation = new CargoOperation
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
               
            };
            _CargoOperationService.TInsert(CargoOperation);
            return Ok("Kargo İşlemi ekleme başarılı");
            //Burada sadece istediğimiz parametre veri girişi olarak olsun diye yaptık.
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Kargo İşlemi başarıyla Silindi.");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByIdCargoOperation(int id)
        {
            var values = _CargoOperationService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation CargoOperation2 = new CargoOperation
            {
               Barcode=updateCargoOperationDto.Barcode,
               Description=updateCargoOperationDto.Description,
               OperationDate=updateCargoOperationDto.OperationDate,
            };
            _CargoOperationService.TUpdate(CargoOperation2);
            return Ok("Kargo İşlemi  başarıyla güncellendi.");
        }
    }
}

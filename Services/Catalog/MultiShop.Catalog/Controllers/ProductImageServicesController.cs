using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageServicesController : ControllerBase
    {
        private readonly IProductImageServices _productImageServices;

        public ProductImageServicesController(IProductImageServices productImageServices)
        {
            _productImageServices = productImageServices;
        }

        [HttpGet]

        public async Task<IActionResult> ProductImageList()
        {

            var values = await _productImageServices.GetAllProductImageAsyn();
            return Ok(values);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdProductImageList(string id)
        {
            var values = await _productImageServices.GetByIdProductImageAsyn(id);
            return Ok(values);

        }

        [HttpPost]

        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageServices.CreateProductImageAsyn(createProductImageDto);
            return Ok("Ürün Resimi Başarıyla Eklendi");

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageServices.DeleteProductImageAsyn(id);
            return Ok("Ürün Resimi Başarıyla Silindi");


        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageServices.UpdateProductImageAsyn(updateProductImageDto);
            return Ok("Ürün Resimi Başarıyla Güncellendi");

        }

    }
}

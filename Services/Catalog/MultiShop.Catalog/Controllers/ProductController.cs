using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet] // tüm hepsini getir APİ
        public async Task<IActionResult> CategoryList()
        {
            var values = await _productService.GetAllProductAsyn();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductList(string id)
        {
            var values = await _productService.GetByIdProductAsyn(id);
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsyn(createProductDto);
            return Ok("Ürün başarıyla eklendi");

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsyn(id);
            return Ok("Ürün başarıyla silindi");

        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsyn(updateProductDto);
            return Ok("Ürün başarıyla güncellendi");


        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailServices;

        public ProductDetailController(IProductDetailServices productDetailServices)
        {
            _productDetailServices = productDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList() 
        {
            var values = await _productDetailServices.GetAllProductDetailAsyn();
            return Ok(values);
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetailList(string id) 
        {
            var values = await _productDetailServices.GetByIdProductDetailAsyn(id);
            return Ok(values);
        
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto) 
        {
            await _productDetailServices.CreateProductDetailAsyn(createProductDetailDto);
            return Ok("Ürün Detayı Başarıyla Eklendi");
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        { 
            await _productDetailServices.DeleteProductDetailAsyn(id);
            return Ok("Ürün Detayı Başarıyla Silindi");
        
        
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto) 
        {
            await _productDetailServices.UpdateProductDetailAsyn(updateProductDetailDto);
            return Ok("Ürün Detayı Başarıyla Güncellendi");
        
        }
    }
}

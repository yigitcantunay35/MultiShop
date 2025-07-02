using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet] // tüm hepsini getir APİ
        public async Task<IActionResult> CategoryList() 
        {
            var values = await _categoryService.GetAllCategoryAsyn();
            return Ok(values);
        
        }

        [HttpGet("{id}")] // id'ye göre getir.
        public async Task<IActionResult> GetByIdCategoryList(string id) 
        {
            var values = await _categoryService.GetByIdCategoryAsyn(id);
            return Ok(values);
        
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto) 
        {
            await _categoryService.CreateCategoryAsyn(createCategoryDto);
            return Ok("Ürün başarıyla eklendi");    
        
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCategory(string id) 
        {
            await _categoryService.DeleteCategoryAsyn(id);
            return Ok("Kategori başarıyla silindi");
        
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto) 
        {
            await _categoryService.UpdateCategoryAsyn(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi");
        
        
        }


    }
}

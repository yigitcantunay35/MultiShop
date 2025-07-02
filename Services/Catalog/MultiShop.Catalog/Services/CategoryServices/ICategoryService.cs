using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsyn(); // bütün verileri getirecek.
        Task CreateCategoryAsyn(CreateCategoryDto createCategoryDto); // ekleme işlemi yapıcak
        Task UpdateCategoryAsyn(UpdateCategoryDto updateCategoryDto); // güncelleme
        Task DeleteCategoryAsyn(string id); // silme
        Task <GeyByIdCategoryDto> GetByIdCategoryAsyn(string id); // id'ye göre getirme işlemi
    }
}

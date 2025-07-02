using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsyn();  // bütün verileri getirecek.
        Task CreateProductAsyn(CreateProductDto createProductDto); // baştan veri girm e
        Task UpdateProductAsyn(UpdateProductDto updateProductDto); // güncelleme
        Task DeleteProductAsyn(string id); // silme
        Task<GetByIdProductDto> GetByIdProductAsyn(string id); // id'ye göre getirme
    }
}

using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageServices
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsyn(); // bütün verileri getirecek.
        Task CreateProductImageAsyn(CreateProductImageDto createProductIamgeDto); // ekleme işlemi yapıcak
        Task UpdateProductImageAsyn(UpdateProductImageDto updateProductIamgeDto); // güncelleme
        Task DeleteProductImageAsyn(string id); // silme
        Task<GetByIdProductImageDto> GetByIdProductImageAsyn(string id); // id'ye göre getirme işlemi
    }
}

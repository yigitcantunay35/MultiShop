using MultiShop.Catalog.Dtos.ProductDetailDtos;


namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailServices
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsyn(); // bütün verileri getirecek.
        Task CreateProductDetailAsyn(CreateProductDetailDto createProductDetailDto); // ekleme işlemi yapıcak
        Task UpdateProductDetailAsyn(UpdateProductDetailDto updateProductDetailDto); // güncelleme
        Task DeleteProductDetailAsyn(string id); // silme
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsyn(string id); // id'ye göre getirme işlemi

    }
}

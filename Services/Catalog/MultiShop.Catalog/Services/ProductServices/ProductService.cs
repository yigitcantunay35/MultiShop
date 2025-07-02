using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _ProductCollection;

        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
            
        }

        public async Task CreateProductAsyn(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto); 
            await _ProductCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsyn(string id)
        {
            await _ProductCollection.DeleteOneAsync(x=>x.ProductId == id);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsyn(string id)
        {
           var values = await _ProductCollection.Find<Product>(x=>x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsyn()
        {
            var value = await _ProductCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(value);
        }

        public async Task UpdateProductAsyn(UpdateProductDto updateProductDto)
        {
           var values = _mapper.Map<Product>(updateProductDto);
            await _ProductCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateProductDto.ProductId,values);
        }
    }
}

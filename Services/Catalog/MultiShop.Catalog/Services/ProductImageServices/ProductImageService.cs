﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings) 
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
            
            
        }

        public async Task CreateProductImageAsyn(CreateProductImageDto createProductImageDto)
        {
           var value = _mapper.Map<ProductImage>(createProductImageDto);
           await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsyn(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x=>x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsyn()
        {
            var value = await _ProductImageCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(value);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsyn(string id)
        {
            var values = await _ProductImageCollection.Find<ProductImage>(x=>x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsyn(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _ProductImageCollection.FindOneAndReplaceAsync(x=>x.ProductImageId == updateProductImageDto.ProductImageId,values);
        }
    }
}

using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isactive,@validate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code",createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isactive", createCouponDto.IsActive);
            parameters.Add("@validate", createCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            var query = "delete from Coupons where CouponId=@couponid";
            var parameters = new DynamicParameters();
            parameters.Add("@couponid", id);
            using (var connection = _dapperContext.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _dapperContext.CreateConnection()) 
            {
                var value = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return value.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponDtoAsync(int id)
        {
            var query = "select * from Coupons where CouponId=@couponid";
            var parameters = new DynamicParameters();
            parameters.Add("@couponid", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update Coupons set Code=@code,Rate=@rate,IsActive=@isactive,ValidDate=@validate where CouponId=@couponid ";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isactive", updateCouponDto.IsActive);
            parameters.Add("@validate", updateCouponDto.ValidDate);
            parameters.Add("@couponid", updateCouponDto.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        //*Metot isimlerini arayüzdeki ile birebir aynı hale getirmek gerek ve bunu unutma
        /* 
            CS0535: 'DiscountService', 'IDiscountService' arayüzünün üyelerini uygulamaz
         Bu hatanın anlamı: DiscountService sınıfı, IDiscountService arayüzünde tanımlı olan tüm metotları doğru imzayla (yani isim, parametre tipi ve dönüş tipi) uygulamıyor demektir.

        Hataların Kaynağı: Metot İsim Uyumsuzluğu
         Senin IDiscountService arayüzünde şu metotlar tanımlı
        --------------------------------------------------------
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponDtoAsync(int id);

        Ama senin DiscountService sınıfındaki metot isimleri şöyle:
        ---------------------------------------------------------
        Task<List<ResultDiscountCouponDto>> GetAllCouponAsync(); // HATALI isim
        Task CreateCouponAsync(...);                             // HATALI isim
        Task UpdateCouponAsync(...);                             // HATALI isim
        Task DeleteCouponAsync(...);                             // HATALI isim
        Task<GetByIdDiscountCouponDto> GetByIdCouponDtoAsync(...); // HATALI isim

        Çözüm
        Metot isimlerini arayüzdeki ile birebir aynı hale getirmen gerekiyor. Aşağıdaki gibi isimlerini değiştir:
        eski :public async Task<List<ResultDiscountCouponDto>> GetAllCouponAsync()
        Yeni : public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()

        Sonuç
        Metot isimlerini arayüzdekiyle birebir eşleştir, eksik tablo adını da düzelt. Sonrasında hata ortadan kalkacaktır.



         
         */
    }
}

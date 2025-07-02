using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using MultiShop.Basket.Settings;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //Bir ku7llan�c�n�n zorunlu olasm�n� atad�k.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub"); // => bununla birlikte sub de�erini C# taraf�nfa direkt oalrak alam�yorduk ve ald�k. => bu eski olan yer.
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.MapInboundClaims = false;
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceBasket"; // => ResourceCatalog kar��l���ndaki olan yetkilerne ise onlara bakarak eri�im elde edicek.
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings")); // appsettings.json i�erisindeki ba�lant�s�n� konfig�re ettik.
builder.Services.AddSingleton<RedisService>(sp => 
{
    var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);
    redis.Connect();
    return redis;
});

builder.Services.AddControllers( opt => 
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy)); //Burada ise kullan�c� oturum zorunlu hale geldi.
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

namespace MultiShop.Basket.LoginServices
{
    public class LoginService: ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }
        public string GetUserId
        {
            get
            {
                var httpContext = _httpcontextAccessor.HttpContext;
                if (httpContext == null)
                {
                    Console.WriteLine("HttpContext null!");
                    return "NO_CONTEXT";
                }

                var sub = httpContext.User.FindFirst("sub");
                if (sub == null)
                {
                    Console.WriteLine("sub claim bulunamadı!");
                    return "NO_CLAIM";
                }

                return sub.Value;
            }
        }


        //public string GetUserId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;
        //Burada ise kullanıcının id'sini yakalamak için burayı yazdık.
    }
}

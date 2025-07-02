using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands
{
    //Bunların her birinin açıklaması açıklama.txt içerisinde bulabilirsin neden olduğunu.
    public class CreateAddressCommands
    {
        public string? UserId { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Detail { get; set; }
    }
}

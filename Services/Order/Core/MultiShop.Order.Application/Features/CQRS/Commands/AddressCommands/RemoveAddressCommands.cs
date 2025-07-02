using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands
{
    public class RemoveAddressCommands
    {
        public int AddressId { get; set; }

        public RemoveAddressCommands(int id)
        {
            AddressId = id;
            
        }
    }
}

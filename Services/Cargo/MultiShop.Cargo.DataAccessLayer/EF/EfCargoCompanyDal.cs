using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EF
{
    public class EfCargoCompanyDal:GenericRepoSitory<CargoCompany>,ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context): base(context)
        {
            
        }
    }
}

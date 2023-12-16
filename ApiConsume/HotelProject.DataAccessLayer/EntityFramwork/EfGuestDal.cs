using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramwork
{
    public class EfGuestDal:GenericRepository<Guest>,IGuestDal
    {
        public EfGuestDal(Context context) : base(context)
        {

        }

        public int GetGuestCount()
        {
            var context=new Context();
            var countGuest = context.Guests.Count();
            return countGuest;
        }
    }
}

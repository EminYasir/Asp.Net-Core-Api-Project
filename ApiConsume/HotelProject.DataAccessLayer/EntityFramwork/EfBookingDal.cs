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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {

        }
        Context context = new Context();
        //public void BookingStatusChangeApproved(int id)
        //{

        //    var values = context.Bookings.Find(id);
        //    values.Status = "Onaylandı";
        //    context.SaveChanges();
        //}

        public int GetBookingCount()
        {
            var bookingCount = context.Bookings.Count();
            return bookingCount;
        }

        public List<Booking> GetLast6Booking()
        {
            var values = context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return values;
        }

        public void BookingStatusChangeAproved2(int id)
        {
            var context = new Context();
            var values = context.Bookings.FirstOrDefault(x => x.BookingID == id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            var value=context.Bookings.FirstOrDefault(y => y.BookingID == id);
            value.Status= "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            var value=context.Bookings.FirstOrDefault(x=> x.BookingID==id);
            value.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }
    }
}

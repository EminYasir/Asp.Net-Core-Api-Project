﻿using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        //void BookingStatusChangeApproved(int id);
        int GetBookingCount();

        List<Booking> GetLast6Booking();

        void BookingStatusChangeAproved2(int id);
        void BookingStatusChangeCancel(int id);
        void BookingStatusChangeWait(int id);
    }
}

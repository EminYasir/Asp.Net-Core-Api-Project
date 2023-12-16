﻿using HotelProject.DataAccessLayer.Abstract;
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
    public class EfRoomDal : GenericRepository<Room> , IRoomDal
    {
        public EfRoomDal(Context context) : base(context)
        {

        }

        public int getRoomCount()
        {
            var context=new Context();
            var roomCount = context.Rooms.Count();
            return roomCount;
        }
    }
}

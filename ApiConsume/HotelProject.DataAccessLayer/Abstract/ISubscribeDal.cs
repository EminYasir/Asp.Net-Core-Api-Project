using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface ISubscribeDal : IGenericDal<Subscribe>
    {
        public void Delete(Subscribe t)
        {
            throw new NotImplementedException();
        }

        public Subscribe GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subscribe> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Subscribe t)
        {
            throw new NotImplementedException();
        }

        public void Update(Subscribe t)
        {
            throw new NotImplementedException();
        }
    }
}

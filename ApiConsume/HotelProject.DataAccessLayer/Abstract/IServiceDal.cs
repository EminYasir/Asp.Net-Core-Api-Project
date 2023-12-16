using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IServiceDal : IGenericDal<Service>
    {
        public void Delete(Service t)
        {
            throw new NotImplementedException();
        }

        public Service GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Service t)
        {
            throw new NotImplementedException();
        }

        public void Update(Service t)
        {
            throw new NotImplementedException();
        }
    }
}

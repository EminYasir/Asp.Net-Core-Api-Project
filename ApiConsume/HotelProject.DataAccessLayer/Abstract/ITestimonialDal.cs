using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface ITestimonialDal : IGenericDal<Testimonial>
    {
        public void Delete(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public Testimonial GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void Update(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}

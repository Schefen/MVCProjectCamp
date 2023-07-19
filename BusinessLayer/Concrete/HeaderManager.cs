using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeaderManager : IHeaderService
    {
        IHeaderDal _headerDal;

        public HeaderManager(IHeaderDal headerDal)
        {
            _headerDal = headerDal;
        }

        public Header GetById(int id)
        {
            return _headerDal.Get(x => x.HeaderId == id);
        }

        public List<Header> GetList()
        {
            return _headerDal.List();
        }

        public void HeaderAdd(Header header)
        {
            _headerDal.Insert(header);
        }

        public void HeaderDelete(Header header)
        {
            _headerDal.Update(header); 
        }

        public void HeaderUpdate(Header header)
        {
            _headerDal.Update(header);
        }
    }
}

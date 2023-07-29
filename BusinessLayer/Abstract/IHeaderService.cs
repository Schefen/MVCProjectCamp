using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeaderService
    {
        List<Header> GetList();
        List<Header> GetListByWriter();

        void HeaderAdd(Header header);

        Header GetById(int id);
        void HeaderDelete(Header header);
        void HeaderUpdate(Header header);
    }
}

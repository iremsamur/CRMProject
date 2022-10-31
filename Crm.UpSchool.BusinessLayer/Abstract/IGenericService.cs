using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TInsert(T t);//data access'dan ayırmak için başına T ekliyoruz.
        void TUpdate(T t);
        void TDelete(T t);
        List<T> TGetList();

        T TGetByID(int id);
    }
}

using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Concrete
{
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public void TDelete(Supplier t)
        {
            throw new NotImplementedException();
        }

        public Supplier TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> TGetList()
        {
            return _supplierDal.GetList();
        }

        public void TInsert(Supplier t)
        {
            _supplierDal.Insert(t);
        }

        public void TUpdate(Supplier t)
        {
            throw new NotImplementedException();
        }
    }
}

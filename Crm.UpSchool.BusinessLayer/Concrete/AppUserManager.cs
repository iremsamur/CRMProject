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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()
        {
            throw new NotImplementedException();
        }

        public string TGetSelectedUserName(string emailAddresss)
        {
            return _appUserDal.GetSelectedUserName(emailAddresss);
        }

        public void TInsert(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            _appUserDal.Update(t);
        }
    }
}

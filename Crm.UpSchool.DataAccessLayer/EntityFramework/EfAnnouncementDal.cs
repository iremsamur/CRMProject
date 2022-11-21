using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Crm.UpSchool.DataAccessLayer.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public List<Announcement> ContainAAnnouncement()
        {
            using(var context = new Context())
            {
                //a ile başlayanlar
                var values = context.Announcements.Where(x => x.Title.Contains("a")).ToList();
                return values;
                
            }
          
        }
    }
}

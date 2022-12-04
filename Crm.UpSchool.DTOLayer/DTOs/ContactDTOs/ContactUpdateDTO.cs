using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DTOLayer.DTOs.ContactDTOs
{
   public class ContactUpdateDTO
    {
        //güncelleme için entity içindeki ID dahil tüm propertylere ihtiyacım var
        //o yüzden hepsini koydum.
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}

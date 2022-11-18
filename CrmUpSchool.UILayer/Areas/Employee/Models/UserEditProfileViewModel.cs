using Microsoft.AspNetCore.Http;

namespace CrmUpSchool.UILayer.Areas.Employee.Models
{
    public class UserEditProfileViewModel
    {
        //view modelde sadece ihtiyaç duyulan veriler tanımlanır
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl{ get; set; }
        public IFormFile Image { get; set; }//resim dosyaları için kullanılır.
    }

}

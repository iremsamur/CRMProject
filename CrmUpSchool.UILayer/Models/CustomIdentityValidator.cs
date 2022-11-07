using Microsoft.AspNetCore.Identity;

namespace CrmUpSchool.UILayer.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        //özelleştirilmiş validasyonlar için IdentityErrorDescriber'dan miras alacak
        //Identity'den gelen ingilizce validasyon mesajları yerine kendim
        //o mesajların türkçeleştirerek gelmesini istiyorum.

        public override IdentityError PasswordTooShort(int length)
        {
            //mesela passwordtooshort'u özelleştirelim
            return new IdentityError()
            {
                Code = "PassswordTooShort",
                Description = $"Şifre en az {length} karakter olmalıdır." //"" içinde length içinde $ kullandık.
            };
        }
        //yapıyı kendi istediğim formatta kullanmak için metodu override ediyorum.
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az 1 tane küçük harf giriniz"
            };

        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 tane büyük harf giriniz"
            };

        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az 1 tane sayı girişi yapın"
            };


        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"İlgili mail adresi : {email} zaten sistemde mevcut, lütfen farklı bir mail adresi ile kayıt olun."
            };

        }
        public override IdentityError DuplicateUserName(string username)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"İlgili kullanıcı adı : {username} zaten sistemde mevcut, lütfen farklı bir kullanıcı adı ile kayıt olun."
            };

        }
    }
}

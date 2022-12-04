using AutoMapper;
using Crm.UpSchool.DTOLayer.DTOs.ContactDTOs;
using CrmUpSchool.EntityLayer.Concrete;

namespace CrmUpSchool.UILayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Burada kaynak ve hedef parametrelerini alır. 
            //Hedef bir durumda DTO iken diğerinde entity olabilir. 
            //Eğer ekleme işlemi yapılacaksa veritabanını kullandığım için
            //kaynak entity olur. Diğer durumda ekleme işlemi için değilde
            //mesela UI tarafında o modeli kullanmam gerekiyorsa bu
            //kez hedef DTO olur. O yüzden iki taraflı tanımlarız
            CreateMap<ContactAddDTO, Contact>();
            CreateMap<Contact, ContactAddDTO>();

            CreateMap<ContactListDTO, Contact>();
            CreateMap<Contact, ContactListDTO>();

            CreateMap<ContactUpdateDTO, Contact>();
            CreateMap<Contact, ContactUpdateDTO>();


        }
    }
}

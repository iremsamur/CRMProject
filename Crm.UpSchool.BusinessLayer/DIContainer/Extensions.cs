using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.BusinessLayer.Concrete;
using Crm.UpSchool.BusinessLayer.ValidationRules.ContactValidation;
using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.EntityFramework;
using Crm.UpSchool.DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void Containerdependencies(this IServiceCollection services)
        {
            //Startup içindeki tüm servisleri IServiceCollection'ları burada almak için IServiceCollection'ı veriyoruz.
            //Startup'daki servisler çok fazla olduğu için, business ya da data access layer içinde containerdependencies içinde ServiceCollection burada çağırılır. 
            //Buradaki this ise Bu IServiceCollection'ı kullandığımızı belirtiyor.
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EfEmployeeDal>();
            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDal, EfEmployeeTaskDal>();
            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDal, EfEmployeeTaskDetailDal>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EfCustomerDal>();
            services.AddScoped<ISupplierService, SupplierManager>();
            services.AddScoped<ISupplierDal, EfSupplierDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

        }
        //Automapper için 
        public static void CustomizeValidator(this IServiceCollection services)
        {
            //DTO ve onun ilgili validator eşleştirmelerini burada yazıp tanımlıyoruz
            services.AddTransient<IValidator<ContactAddDTO>, ContactAddValidator>();
            services.AddTransient<IValidator<ContactUpdateDTO>, ContactUpdateValidator>();



        }
    }
}

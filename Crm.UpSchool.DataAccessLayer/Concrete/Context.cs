using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
        //AppUser AspNetIdentityUser'da özelleştirilmiş alanları tanımladığım sınıf
        //Bu gönderdiğim int ise tablomun id'si varsayılan string geldiği için onu int yapmak istiyorum
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-ISO96UVH\\SQLEXPRESS;Database=DbCRM;integrated security=True;");//DataSource='de kullanılabilir.


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            //AppUser sınıfından hem görevi atayan kişi hemde görevin atandığı kişi için
            //ilişki kuruluyor. Kurulan ilişkinin foreign key, hasone, withmany değerleri burada tanımlanır

            modelBuilder.Entity<EmployeeTask>()
                .HasOne(x => x.AssigneeUser)
                .WithMany(y => y.EmployeeTasksAssignee)
                .HasForeignKey(z => z.TaskAssigneeUserID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //şimdi aynı işlemi Alıcı için yapalım
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(x => x.FollowerUser)
                .WithMany(y => y.EmployeeTasksFollower)
                .HasForeignKey(z => z.FollowerUserID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);




        }
        public DbSet<Customer> Customers { get; set; }//migration tablosunun migration içine gelmesiin veritabanına yansıtılmasını burası sağlar.
        //Buraya yazmadığımız entity'ler database'e yansıtılmaz.
        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees
        {
            get; set;
        }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<EmployeeTaskDetail> EmployeeTaskDetail { get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }


    }
}

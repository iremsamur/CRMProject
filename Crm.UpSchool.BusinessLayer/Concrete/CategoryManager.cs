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
    public class CategoryManager : ICategoryService
    {
        
        ICategoryDal _categoryDal;

        //dependency injection
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
            //amacım bağımlılıkları minimize etmektir.
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TInsert(Category t)
        {
            //iş kurallarını burada yazıyoruz
            /*
            if (t.CategoryName != null && t.CategoryName.Length >= 5 && t.CategoryDescription.StartsWith("A"))
            {
                //bu şartları sağlıyorsa ekle
                _categoryDal.Insert(t);

            }
            else
            {
                //hata mesajı
            }
            */
            _categoryDal.Insert(t);

        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}

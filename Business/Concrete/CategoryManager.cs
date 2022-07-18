using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.CategoryId == id);
        }

        public int GetDifferenceBetweenTrueAndFalse()
        {
            var categories = _categoryDal.GetAll();
            int trueCount = 0, falseCount = 0;
            foreach (var item in categories)
            {
                if (item.Status == true)
                {
                    trueCount++;
                }
                if (item.Status == false)
                {
                    falseCount++;
                }
            }
            return Math.Abs(trueCount - falseCount);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}

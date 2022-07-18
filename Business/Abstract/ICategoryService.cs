using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Delete(Category category);
        List<Category> GetAll();
        Category GetById(int id);
        void Update(Category category);
        int GetDifferenceBetweenTrueAndFalse();
    }
}

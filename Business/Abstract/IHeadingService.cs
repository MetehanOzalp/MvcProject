using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        void Add(Heading heading);
        void ChangeStatus(Heading heading);
        void Delete(Heading heading);
        List<Heading> GetAll();
        List<Heading> GetByCategoryName(string categoryName);
        Heading GetById(int id);
        string GetMostRecurringCategory();
        void Update(Heading heading);
    }
}

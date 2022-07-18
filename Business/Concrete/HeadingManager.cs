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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            _headingDal.Add(heading);
        }

        public void ChangeStatus(Heading heading)
        {
            if (heading.Status)
            {
                heading.Status = false;
                _headingDal.Update(heading);
            }
            else if (!heading.Status)
            {
                heading.Status = true;
                _headingDal.Update(heading);
            }
        }

        public void Delete(Heading heading)
        {
            if (heading.Status)
            {
                heading.Status = false;
            }
            _headingDal.Update(heading);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }

        public List<Heading> GetByCategoryName(string categoryName)
        {
            return _headingDal.GetAll(h => h.Category.Name == categoryName);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(h => h.HeadingId == id);
        }

        public string GetMostRecurringCategory()
        {
            var categoryNames = _headingDal.GetRecurringCategoryNames();
            var categories = new Dictionary<string, int>();
            foreach (var category in categoryNames)
            {
                bool isThere = false;
                foreach (var item in categories)
                {
                    if (category.Equals(item.Key))
                    {
                        isThere = true;
                    }
                }
                if (isThere)
                {
                    int value;
                    categories.TryGetValue(category, out value);
                    categories[category] = value + 1;
                }
                else
                {
                    categories.Add(category, 1);
                }
            }
            var mostRecurringCategory = categories.First();
            foreach (var item in categories)
            {
                if (item.Value > mostRecurringCategory.Value)
                {
                    mostRecurringCategory = item;
                }
            }
            return mostRecurringCategory.Key;
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}

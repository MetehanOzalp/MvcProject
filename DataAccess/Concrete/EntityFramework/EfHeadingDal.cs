using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHeadingDal : EfEntityRepositoryBase<Heading, Context>, IHeadingDal
    {
        public List<string> GetRecurringCategoryNames()
        {
            using (Context context = new Context())
            {
                var categoryNames = context.Headings.Select(h => h.Category.Name).ToList();
                return categoryNames;
            }
        }
    }
}

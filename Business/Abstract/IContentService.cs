using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        void Add(Content content);
        void Delete(Content content);
        List<Content> GetAll();
        Content GetById(int id);
        List<Content> GetContentsByHeadingId(int headingId);
        void Update(Content content);
    }
}

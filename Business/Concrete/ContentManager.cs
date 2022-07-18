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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            throw new NotImplementedException();
        }

        public void Delete(Content content)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetAll()
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentsByHeadingId(int headingId)
        {
            return _contentDal.GetAll(c => c.HeadingId == headingId);
        }

        public void Update(Content content)
        {
            throw new NotImplementedException();
        }
    }
}

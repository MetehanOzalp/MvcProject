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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesByReceiver(string mail)
        {
            return _messageDal.GetAll(m => m.ReceiverMail == mail);
        }

        public List<Message> GetMessagesBySender(string mail)
        {
            return _messageDal.GetAll(m => m.SenderMail == mail);
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        void Add(Message message);
        void Delete(Message message);
        Message GetById(int id);
        List<Message> GetMessagesByReceiver(string mail);
        List<Message> GetMessagesBySender(string mail);
        void Update(Message message);
    }
}

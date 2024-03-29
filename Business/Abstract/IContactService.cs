﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        List<Contact> GetAll();
        Contact GetById(int id);
        void Update(Contact contact);
    }
}

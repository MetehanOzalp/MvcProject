﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
        where T : class, new()
    {
        void Add(T t);
        void Delete(T t);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter);
        void Update(T t);
    }
}

using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        DbSet<TEntity> _object;

        public EfEntityRepositoryBase()
        {
            TContext context = new TContext();
            _object = context.Set<TEntity>();
        }

        public void Add(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(t);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(t);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll()
        {
            return _object.ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(TEntity t)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(t);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

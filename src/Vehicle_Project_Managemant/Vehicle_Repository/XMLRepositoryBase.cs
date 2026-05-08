using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Vehicle_Domain;
using Vehicle_Source;

namespace Vehicle_Repository
{
    public class XMLRepositoryBase<TContext, TEntity, TKey> : IRepository<TEntity, TKey>
        where TContext : XMLSet<TEntity>
        where TEntity : class
    {
        private XMLSet<TEntity> _context;

        public XMLRepositoryBase(string fileName)
        {
            _context = new XMLSet<TEntity>(fileName);
        }

        public ICollection<TEntity> GetAll()
        {
            return _context.Data;
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var list = _context.Data.AsQueryable().Where(predicate).ToList();
                return list;
            }
            catch
            {
                return null;
            }
        }

        public TEntity Get(TKey id)
        {
            try
            {
                var items = _context.Data.Cast<IEntity<TKey>>().ToList();
                return items.FirstOrDefault(f => f.ID.Equals(id)) as TEntity;
            }
            catch
            {
                return null;
            }
        }

        public TKey Insert(TEntity model)
        {
            var list = _context.Data;

            // ID auto increment
            if (model is IEntity<int> entity)
            {
                if (list.Count > 0 && list.First() is IEntity<int>)
                {
                    int nextId = list.Cast<IEntity<int>>().Max(x => x.ID) + 1;
                    entity.ID = nextId;
                }
                else
                {
                    entity.ID = 1;
                }
            }

            list.Add(model);
            _context.Data = list;
            return default(TKey);
        }


        public bool Update(TEntity model)
        {
            try
            {
                IEntity<TKey> imodel = model as IEntity<TKey>;
                var items = _context.Data.Cast<IEntity<TKey>>().ToList();
                items.Remove(items.FirstOrDefault(f => f.ID.Equals(imodel.ID)));
                items.Add(imodel);
                _context.Data = items.Cast<TEntity>().ToList();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TKey id)
        {
            try
            {
                var items = _context.Data.Cast<IEntity<TKey>>().ToList();
                items.Remove(items.First(f => f.ID.Equals(id)));
                _context.Data = items.Cast<TEntity>().ToList();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(TKey id)
        {
            return Delete(id);
        }
    }
}

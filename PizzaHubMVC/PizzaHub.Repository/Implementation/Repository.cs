﻿using Microsoft.EntityFrameworkCore;
using PizzaHub.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Repository.Implementation
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _db;
        public Repository(DbContext db)
        {
                _db = db;
        }
        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void Delete(int id)
        {
           TEntity entity = _db.Set<TEntity>().Find(id);
            if(entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
            }
        }

        public TEntity Find(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }
    }
}

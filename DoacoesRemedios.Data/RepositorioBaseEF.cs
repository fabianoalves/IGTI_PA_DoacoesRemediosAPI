using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DoacoesRemedios.Data.Extensions;

namespace DoacoesRemedios.Data
{
    public class RepositorioBaseEF<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public bool ShowLog { get; set; }
        private readonly GNLiteDbContext _context;
        public GNLiteDbContext Context { get { return _context; } }

        public RepositorioBaseEF(GNLiteDbContext context)
        {
            _context = context;
        }
        //public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();
        public IQueryable<TEntity> All
        {
            get {
                if (ShowLog) _context.LogSQLToConsole();
                return _context.Set<TEntity>().AsQueryable();
            }
        }
        public void Update(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
            _context.SaveChanges();
            if (ShowLog) _context.LogSQLToConsole();
        }

        public void Delete(params TEntity[] obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
            if (ShowLog) _context.LogSQLToConsole();
        }

        public TEntity Get(int key)
        {
            TEntity entity = _context.Find<TEntity>(key);
            if(ShowLog) _context.LogSQLToConsole();
            return entity;
        }

        public void Add(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
            if (ShowLog) _context.LogSQLToConsole();
        }
    }
}

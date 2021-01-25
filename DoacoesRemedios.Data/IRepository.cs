using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoacoesRemedios.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool ShowLog { get; set; }
        GNLiteDbContext Context{get;}
        IQueryable<TEntity> All { get; }
        TEntity Get(int key);
        void Add(params TEntity[] obj);
        void Update(params TEntity[] obj);
        void Delete(params TEntity[] obj);
    }
}

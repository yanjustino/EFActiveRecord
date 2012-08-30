using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace d2d.Models.repositorios
{
    public abstract class ActiveRecord<T> : IDisposable where T : class
    {
        public int Id { get; set; }
        protected DataContext db { get; private set; }

        // DML - Linguagem de Manipulação de Dados

        public virtual void Save()
        {
            DataSet().Add(this);
            db.SaveChanges();
        }

        public virtual void Update()
        {
            var current = DataSet().Find(this.Id);
            db.Entry(current).CurrentValues.SetValues(this);
            db.SaveChanges();
        }

        public virtual void Delete()
        {
            var current = DataSet().Find(this.Id);
            DataSet().Remove(current);
            db.SaveChanges();
        }

        // DQL - Linguagem de Consulta de Dados

        public T Find(int id)
        {
            return (T)DataSet().Find(id);
        }

        public ICollection<T> Where(Func<T, bool> predicate)
        {
            return (DataSet() as IEnumerable<T>).Where(predicate).ToList();
        }

        public ICollection<T> All()
        {
            return (DataSet() as IEnumerable<T>).ToList();
        }

        // Constructors and Destructors

        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

        private DbSet DataSet()
        {
            CreateDataContextIfNotExists();
            return db.Set<T>();
        }

        private void CreateDataContextIfNotExists()
        {
            if (db == null) db = new DataContext();
        }
    }
}
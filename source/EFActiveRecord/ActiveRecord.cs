using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFActiveRecord
{
    public abstract class ActiveRecord<T> where T : class
    {
        public int Id { get; set; }
        protected DbContext Context { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Insert DbContext</param>
        public ActiveRecord(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Save a New Model in DataBase
        /// </summary>
        public virtual void Save()
        {
            Context.Set(this.GetType()).Add(this);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update Model
        /// </summary>
        public virtual void Update()
        {
            Binding();
            var current = Context.Set<T>().Find(this.Id);
            Context.Entry(current).CurrentValues.SetValues(this);
            Context.SaveChanges();
        }

        /// <summary>
        /// Set data binding model
        /// </summary>
        private void Binding() 
		{ 
            foreach (System.Reflection.PropertyInfo item in this.GetType().GetProperties())
            {
                if (item.PropertyType.BaseType == null)
                    continue;

                if (item.PropertyType.BaseType.Name.Contains("ActiveRecord"))
                    Attach(item.GetValue(this, null));
            }
		}

        /// <summary>
        /// Attach cascaded model 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="attach"></param>
        private void Attach(object attach)
        {
            int id = (int)attach.GetType().GetProperty("Id").GetValue(attach, null);
            var current = Context.Set(attach.GetType()).Find(id);
            Context.Entry(current).CurrentValues.SetValues(attach);
            attach = current;
        }

        /// <summary>
        /// Delete Register
        /// </summary>
        public virtual void Delete()
        {
            var current = Context.Set<T>().Find(this.Id);
            Context.Set<T>().Remove(current);
            Context.SaveChanges();
        }

        /// <summary>
        /// Find especifc register in Data Table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find(int id)
        {
            return (T)Context.Set<T>().Find(id);
        }

        /// <summary>
        /// Get all Registers On Table
        /// </summary>
        public ICollection<T> All()
        {
            return (Context.Set<T>() as IEnumerable<T>).ToList();
        }

        /// <summary>
        /// Query regi
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public ICollection<T> Where(Func<T, bool> predicate)
        {
            return (Context.Set<T>() as IEnumerable<T>).Where(predicate).ToList();
        }
    }
}
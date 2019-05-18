using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL;

namespace ToDoList.BLL.Repository
{
    public abstract class RepositoryBase<T> : IDisposable where T:class
    {
        internal static MyContext DbContext;
        private static DbSet<T> DbObject;
        public bool IsDisposed { get; set; }

        protected RepositoryBase()
        {
            DbContext = DbContext ?? new MyContext();
            TimeSpan dd = DateTime.Now - DbContext.InstanceDate;
            if (IsDisposed) DbContext = new MyContext();
            if (dd.TotalMinutes > 30) DbContext = new MyContext();
            DbObject = DbContext.Set<T>();
        }
        public int Save()
        {
            return DbContext.SaveChanges();
        }
        public List<T> GetAll()
        {
            return DbObject.ToList();
        }
        public T GetById(params object[] keys)
        {
            return DbObject.Find(keys);
        }
        public int Insert(T entity)
        {
            DbObject.Add(entity);
            return DbContext.SaveChanges();
        }
        public int Delete(T entity)
        {
            DbObject.Remove(entity);
            return DbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            DbObject.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            return this.Save();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(obj: this);
            this.IsDisposed = true;
        }
    }
}

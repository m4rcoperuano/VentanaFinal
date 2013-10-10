using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using VentanaFinal.Core.Interfaces;

namespace VentanaFinal.Core.Repositories
{
    public class Repository : IRepository
    {
        private VentanaEntities db;

        public Repository()
        {
            this.db = new VentanaEntities();
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                db.Set<T>().Add(entity);
            }
            catch (DbEntityValidationException exception)
            {
                this.DisplayValidationErrors(exception);
            }
        }
        public void Modify<T>(T entity) where T : class
        {
            try
            {
                db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            }
            catch (DbEntityValidationException exception)
            {
                this.DisplayValidationErrors(exception);
            }
        }
        public void Delete<T>(T entity) where T : class
        {
            db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
        }
        public T Single<T>(Func<T, bool> predicate) where T : class
        {
            return db.Set<T>().SingleOrDefault(predicate);
        }
        public IEnumerable<T> Many<T>(Func<T, bool> predicate) where T : class
        {
            return db.Set<T>().Where(predicate);
        }

        public void CommitAndDispose()
        {
            db.SaveChanges();
            db.Dispose();
        }

        private void DisplayValidationErrors(DbEntityValidationException exception)
        {
            string errors = "";
            foreach (var validationErrors in exception.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    errors += String.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    errors += ", ";
                }
            }

            throw new Exception("Validation Errors: " + errors);
        }

        public void NewContext()
        {
            db = new VentanaEntities();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}

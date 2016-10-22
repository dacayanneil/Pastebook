using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastebookEFModel;

namespace PastebookDataAccessLayer
{
    public class GenericDataAccess<T> where T : class
    {
        public int Create(T newEntity)
        {
            int status = 0;

            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    context.Entry(newEntity).State = System.Data.Entity.EntityState.Added;
                    status = context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public List<T> Retrieve()
        {
            List<T> entityList = new List<T>();
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    entityList = context.Set<T>().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return entityList;
        }

        public T RetrieveByID(int id)
        {
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    return context.Set<T>().Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(T newEntity)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    context.Entry(newEntity).State = System.Data.Entity.EntityState.Modified;
                    status = context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }

        public int Delete(T newEntity)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    context.Entry(newEntity).State = System.Data.Entity.EntityState.Deleted;
                    status = context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return status;
        }
    }
}

using DataAccessLayer.Abstarct;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{

    //Tek bir entitymiz olduğu için şu an gerek olmayabilir ama ilerde birden fazla entity olduğunda Generic Repository çok öenmli olacak.
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        
        public T Add(T entity)
        {
            using var c = new MyContext();
            c.Add(entity);
            c.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            using var c = new MyContext();
            c.Remove(entity);
            c.SaveChanges();
            return entity;
        }

        public T GetById(string id)
        {
            using var c = new MyContext();
            return c.Set<T>().Find(id);
        }

        public ICollection<T> GetListAll()
        {
            using var c = new MyContext();
            return c.Set<T>().ToList();
        }

        public void Save()
        {
            using var c = new MyContext();
            c.SaveChanges();
        }


    }
}

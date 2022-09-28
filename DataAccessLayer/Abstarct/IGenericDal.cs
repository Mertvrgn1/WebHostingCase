using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstarct
{

    //Tek bir entitymiz olduğu için şu an gerek olmayabilir ama ilerde birden fazla entity olduğunda Generic Repository çok öenmli olacak.

    public interface IGenericDal<T> where T : class
    {
        T Add(T entity);
        T Delete (T entity);
        ICollection<T> GetListAll();
        T GetById(string id);
        void Save();

    }
}

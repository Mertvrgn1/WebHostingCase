using DataAccessLayer.Abstarct;
using DataAccessLayer.Context;
using WebHosting.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{

    //Eğer bu proje gibi tek bir entity var ise generic bir yapı oluşturmanıza gerek olmayacağı için bu şekilde de bir repository oluşturabilirsiniz.
    public class HostingRepository : IHostingDal
    {
        MyContext c = new MyContext();

        public void AddHostingAccount(Hosting hosting)
        {
            c.Add(hosting);
            c.SaveChanges();
        }

        public void DeleteHostingAccount(Hosting hosting)
        {
            c.Remove(hosting);
            c.SaveChanges();
        }

        public ICollection<Hosting> GetAllHostingAccount()
        {
           return c.Hostings.ToList();
        }

        public Hosting GetHostingAccountByDomainName(string hostingDomainName)
        {
            return c.Hostings.Find(hostingDomainName);
        }
    }
}

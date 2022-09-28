using WebHosting.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstarct
{

    //Eğer bu proje gibi tek bir entity var ise generic bir yapı oluşturmanıza gerek olmayacağı için bu şekilde de bir repository oluşturabilirsiniz.

    public interface IHostingDal
    {
        ICollection<Hosting> GetAllHostingAccount();
        void AddHostingAccount(Hosting hosting);
        void DeleteHostingAccount(Hosting hosting);
        Hosting GetHostingAccountByDomainName(string hostingDomainName);


    }
}

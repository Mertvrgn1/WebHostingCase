using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHosting.EntityLayer.Entities
{
    public class Hosting
    {
        [Key]
        public string HostingDomainName { get; set; }
        public string HostingPackage { get; set; }
        public string Message { get; set; }
        public int RamUsage { get; set; }
        public int RamMax { get; set; }
        public int CpuLoad { get; set; }
        public int IncomingConnections { get; set; }

    }
}

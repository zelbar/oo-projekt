using StudIS.DAL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLliteConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new NHibernateService2();
            var session = service.OpenSession();
            Console.ReadKey();
        }
    }
}

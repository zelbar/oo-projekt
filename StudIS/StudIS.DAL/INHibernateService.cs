using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.DAL
{
    public interface INHibernateService
    {
        ISession OpenSession();
    }
}

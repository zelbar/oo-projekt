using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.Users;
using FluentNHibernate.Mapping;

namespace StudIS.DAL.Mappings
{
    public class AdministratorMap : SubclassMap<Administrator>
    {
        public AdministratorMap()
        {
            DiscriminatorValue("administrator");
        }
    }
}

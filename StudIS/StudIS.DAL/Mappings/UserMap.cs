using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using FluentNHibernate.Mapping;

namespace StudIS.DAL.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Surname).Not.Nullable();
            Map(x => x.NationalIdentificationNumber)
                .Not.Nullable().Unique();
            Map(x => x.Email).Unique().Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();

            DiscriminateSubClassesOnColumn("role");
        }
    }
}

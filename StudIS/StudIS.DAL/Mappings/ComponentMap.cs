using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using FluentNHibernate.Mapping;

namespace StudIS.DAL.Mappings
{
    public class ComponentMap : ClassMap<Component>
    {
        public ComponentMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.MinimumPointsToPass);
            Map(x => x.MaximumPoints);
            References(x => x.Course);
        }
    }
}

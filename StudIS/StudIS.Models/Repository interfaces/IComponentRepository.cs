using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models.RepositoryInterfaces
{
    public interface IComponentRepository
    {
        Component GetById(int id);
        bool DeleteById(int id);
        Component Update(Component component);
        Component Create(Component component);
    }
}

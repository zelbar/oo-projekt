using StudIS.Models.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using NHibernate;
using NHibernate.Exceptions;

namespace StudIS.DAL.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private ISession _session;

        public ComponentRepository(INHibernateService nhs)
        {
            _session = nhs.OpenSession();
        }


        public Component Create(Component component)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(component);
                transaction.Commit();
                return component;
            }
        }

        public bool DeleteById(int id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var component = GetById(id);

                if (component == null)
                    return false;

                _session.Delete(component);
                try {
                    transaction.Commit();
                } catch (GenericADOException e) {
                    return false;
                }
                return true;
            }
        }

        public Component GetById(int id)
        {
            return _session.Get<Component>(id);
        }

        public Component Update(Component component)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(component);
                transaction.Commit();
                return component;
            }
        }
    }
}

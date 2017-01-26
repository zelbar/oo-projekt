using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Services
{
    public class ComponentServices
    {
        private IComponentRepository _componentRepository;
        private ICourseRepository _courseRepository;

        public ComponentServices(IComponentRepository componentRepository, ICourseRepository courseRepository)
        {

            _componentRepository = componentRepository;
            _courseRepository = courseRepository;

        }


        public Component CreateComponent(string name, int courseId, float minPointsToPass, float maxPoints)
        {
            var course = _courseRepository.GetById(courseId);
            if (course == null)
                return null;

            var component = new Component()
            {
                Name = name,
                Course = course,
                MinimumPointsToPass = minPointsToPass,
                MaximumPoints = maxPoints
            };

            return _componentRepository.Create(component);
        }

        public Component UpdateComponent(string name, int componentId, float minPointsToPass, float maxPoints)
        {
            var component = _componentRepository.GetById(componentId);

            if (component == null)
                return null;

            component.Name = name;
            component.MinimumPointsToPass = minPointsToPass;
            component.MaximumPoints = maxPoints;

            return _componentRepository.Update(component);
        }

        public bool DeleteComponent(int id)
        {
           return _componentRepository.DeleteById(id);
        }
    }
}

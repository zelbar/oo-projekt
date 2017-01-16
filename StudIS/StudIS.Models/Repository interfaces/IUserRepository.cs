using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;

namespace StudIS.Models.RepositoryInterfaces
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        User GetByNationalIdentificationNumbe(string nationalIdentificationNumbe);
        IList<User> GetByCourse(Course course);
        bool DeleteById(int id);
        bool DeleteByNationalIdentificationNumber(string nationalIdentificationNumbe);
        User Update(User user);
        User Create(User user);
        
    }
}

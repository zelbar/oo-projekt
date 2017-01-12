using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;

namespace StudIS.DAL.Repositories
{
    interface IUserRepository
    {
        User GetById(int id);
        User GetByEmail(string email);
        User GetByNationalIdentificationNumbe(string nationalIdentificationNumbe);
        IList<User> GetByCourse(Course course);
        bool DeleteById(int id);
        bool DeleteByNationalIdentificationNumbe(string nationalIdentificationNumbe);
        User Update(User user);
        User Create(User user);
        
    }
}

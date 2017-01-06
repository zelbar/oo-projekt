using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models
{
    public abstract class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string OIB { get; set; }
        public virtual Credentials UserCredentials { get; set; }
    }
}

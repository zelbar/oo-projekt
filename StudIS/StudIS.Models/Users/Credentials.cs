using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Models
{
    public  class Credentials
    {
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual User CredentialsUser { get; set; }
    }
}

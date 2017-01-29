using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models;
using StudIS.Models.Users;

namespace StudIS.Services
{
    public class LoginService
    {
        private IUserRepository _userRepositry;
        public LoginService(IUserRepository userRepository)
        {
            _userRepositry = userRepository;
        }
        /// <summary>
        /// Gets the details of the user with corresponding email and password hash
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passwordHash"></param>
        /// <returns>returns user if user exists, null othervise</returns>
        public User LoginUser(String email, String passwordHash)
        {
            var user = _userRepositry.GetByEmail(email);
            if (user == null)
                return null;
            else if (user.PasswordHash.ToUpper() == passwordHash.ToUpper())
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}

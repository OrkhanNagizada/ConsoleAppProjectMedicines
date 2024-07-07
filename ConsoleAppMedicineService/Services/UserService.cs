using ConsoleAppMedicineService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMedicineService.Services
{
    public class UserService
    {
        public void AddUser(User user)
        {
            DB.users.Add(user);
        }

        public User Login(string email, string password)
        {
            var user = DB.users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            return user;
        }
    }
}

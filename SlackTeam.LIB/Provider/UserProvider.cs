using SlackTeam.LIB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackTeam.LIB.Provider
{
    public class UserProvider: RDBMBaseProvider
    {
        public List<User> GetallUser()
        {
            return base.db.Users.ToList();
        }

        public User getUserByEmail(String Email)
        {
            return base.db.Users.Where(u => u.Email == Email).FirstOrDefault();
        }

        public User GetByEmailAndPassword(String Email, String Password)
        {
            User user = base.db.Users.Where(u => u.Email == Email).FirstOrDefault();
            if(Password.Equals(HashString.Decrypt(user.Password)))
            {
                return user;
            }

            return null;
        }
    }
}

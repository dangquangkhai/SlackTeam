using SlackTeam.LIB.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SlackTeam.LIB.Provider
{
    public class UserProvider: RDBMBaseProvider
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZqwertyuiopasdfghjklzxcvbnm0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
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
            User user = base.db.Users.Where(u => u.Email == Email && u.IsActive == true).FirstOrDefault();
            if(user != null && Password.Equals(HashString.Decrypt(user.Password)))
            {
                return user;
            }

            return null;
        }

        private Boolean GenerateActiveLink(int UserId)
        {
            String url = RandomString(10) + UserId.ToString();
            ActiveUser newActive = base.db.ActiveUsers.Where(u => u.User_ID == UserId).FirstOrDefault();
            if(newActive != null)
            {
                if(newActive.ResetTime < 5)
                {
                    newActive.ResetTime++;
                    newActive.Generate_URL = url;
                    newActive.Expired = DateTime.Now.AddMinutes(30);
                    base.db.SaveChanges();
                    return true;
                }
                return false;
            }
            newActive = new ActiveUser();
            newActive.Created = DateTime.Now;
            newActive.Expired = DateTime.Now.AddMinutes(30);
            newActive.Generate_URL = url;
            newActive.User_ID = UserId;
            newActive.ResetTime = 1;
            base.db.ActiveUsers.Add(newActive);
            base.db.SaveChanges();
            return true;
        }


        public void sentEmailReset(String email, String url)
        {

            String AdminEmail = WebConfigurationManager.AppSettings["emailusername"].ToString();
            String AdminPassword = WebConfigurationManager.AppSettings["emailpassword"].ToString();

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                //Credentials = new NetworkCredential("systemtlr@thanglongreal.vn", "#123456789"),
                Credentials = new NetworkCredential(AdminEmail, AdminPassword),
                EnableSsl = true
            };
            String Domain = WebConfigurationManager.AppSettings["hostname"].ToString();
            String Controller = "Account/ActiveUser?url=" + url;
            client.Send(AdminEmail, email, "Kích hoạt tài khoản | SlackTeam Developer", "Link kích hoạt tài khoản : " + Domain + Controller + " Sau 30 phút link này sẽ không còn khả dụng !!!");

        }

        public Boolean CreateUser(User user)
        {
            if(base.db.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return false;
            }
            user.Password = HashString.Encrypt(user.Password);
            user.Created = DateTime.Today;
            user.IsActive = false;
            base.db.Users.Add(user);
            this.GenerateActiveLink(user.ID);
            this.sentEmailReset(user.Email, base.db.ActiveUsers.Where(u => u.User_ID == user.ID).FirstOrDefault().Generate_URL);
            return true;
        }

        public Boolean ActiveUser(String url)
        {
            ActiveUser link = base.db.ActiveUsers.Where(u => u.Generate_URL == url).FirstOrDefault();
            if (link == null)
            {
                return false;
            }
            else
            {
                if(DateTime.Now <= link.Expired)
                {
                    link.User.IsActive = true;
                    base.db.SaveChanges();
                    return true;
                }
                return false;
            }
        }


    }
}

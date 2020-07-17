using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace CNPMNC.Models
{

    public class Users
    {
        CSDLContext db = null;
        public Users()
        {
            db = new CSDLContext();
        }
        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.UserID);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Hoten = entity.Hoten;
                user.Email = entity.Email;
                db.SaveChanges();
                return true;
            } catch (Exception e)
            {
                return false;
            }
            
        }

        public IEnumerable<User> ListAllPagin(int page, int pageSize)
        {

            return db.Users.OrderBy(x => x.UserID).ToPagedList(page, pageSize);
        }

        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.Username == userName);
        }

        public User ViewDetails(int id)
        {
            return db.Users.Find(id);
        }

        public bool Login(string userName, string passWord)
        {
            var result = db.Users.Count(x => x.Username == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }
    }
}
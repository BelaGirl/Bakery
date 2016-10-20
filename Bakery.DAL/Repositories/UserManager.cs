using Bakery.DAL.Interfaces;
using Bakery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Bakery.DAL.Repositories
{
    public class UserManager:IAuthManager<User>
    {
        private BakeryContext db;

        public UserManager(BakeryContext context)
        {
            db = context;
        }

        public bool Create(User elem)
        {
            if (db.User.Any(u => u.Email == elem.Email))
                return false;
            
                             
            db.User.Add(elem);           
            return true;                                       
        }


        public User Find(Func<User, bool> predicate)
        {
            return db.User.FirstOrDefault(predicate);
        }

        public void Update(User elem)
        {
            db.Entry(elem).State = EntityState.Modified;
        }

        public bool Check(User elem)
        {
            if (db.User.Any(u => u.Email == elem.Email && u.Password == elem.Password))
                return true;

            return false;
        }


         
    }
}

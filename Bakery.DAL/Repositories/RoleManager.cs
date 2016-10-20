using Bakery.DAL.Interfaces;
using Bakery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DAL.Repositories
{
    public class RoleManager : IAuthManager<Role>
    {
        private BakeryContext db;

        public RoleManager(BakeryContext context)
        {
            db = context;
        }

        public bool Create(Role elem)
        {
            if (db.Role.Any(r => r.Name == elem.Name))
                return false;

            db.Role.Add(elem);
            return true;
        }


        public Role Find(Func<Role, bool> predicate)
        {
            return db.Role.FirstOrDefault(predicate);
        }

        public void Update(Role elem)
        {
            db.Entry(elem).State = EntityState.Modified;
        }

        
    }
}

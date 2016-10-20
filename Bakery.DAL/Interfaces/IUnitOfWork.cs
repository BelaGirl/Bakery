using Bakery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DAL.Interfaces
{
   public interface IUnitOfWork:IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }

        IAuthManager<Role> Role { get; }
        IAuthManager<User> User { get; }

        void Save();

    }
}

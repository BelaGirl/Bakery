using Bakery.DAL.Interfaces;
using Bakery.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DAL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private BakeryContext db;
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private UserManager userManager;
        private RoleManager roleManager;

        public UnitOfWork()
        {
            db = new BakeryContext();
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public IAuthManager<Role> Role
        {
            get
            {
                if (roleManager == null)
                    roleManager = new RoleManager(db);
                return roleManager;
            }
        }

        public IAuthManager<User> User
        {
            get
            {
                if (userManager == null)
                    userManager = new UserManager(db);
                return userManager;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

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
    public class ProductRepository :IRepository<Product> 
    {
        private BakeryContext db;

        public ProductRepository(BakeryContext context)
        {
            this.db = context;
        }

        public void Create(Product prod)
        {
            db.Product.Add(prod);
        }

        public void Delete(int id)
        {
            var product = db.Product.Find(id);
            if(product!=null)
                db.Product.Remove(product);
        }

        public void Update(Product prod)
        {
            db.Entry(prod).State = EntityState.Modified;
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return db.Product.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
            return db.Product.Find(id);
        }
               

        public IEnumerable<Product> GetAll()
        {
            return db.Product;
        }

     

        
    }
}

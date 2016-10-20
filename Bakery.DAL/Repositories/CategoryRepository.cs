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
    public class CategoryRepository:IRepository<Category>
    {
        private BakeryContext db;

        public CategoryRepository(BakeryContext context)
        {
            this.db = context;
        }

        public void Create(Category category)
        {
            db.Category.Add(category);
        }

        public void Delete(int id)
        {
            var category = db.Category.Find(id);
            if (category != null)
                db.Category.Remove(category);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return db.Category.Where(predicate).ToList();
        }


        public Category Get(int id)
        {
            return db.Category.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }       

        public void Update(Category prod)
        {
            db.Entry(prod).State = EntityState.Modified;
        }


    }
}

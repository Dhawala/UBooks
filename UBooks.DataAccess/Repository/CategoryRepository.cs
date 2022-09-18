using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBooks.DataAccess.Repository.IRepository;
using UBooks.Models;

namespace UBooks.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository 

    {
        ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db ) :base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            Category category = new Category();

            category.Name = obj.Name;
            category.DisplayOrder = obj.DisplayOrder;
            category.Id = obj.Id;
            _db.Update(category);
        }
    }
}

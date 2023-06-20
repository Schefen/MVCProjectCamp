using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {

        Context _context = new Context();
        DbSet<Category> _object;

        public void Delete(Category category)
        {
            _object.Remove(category);
            _context.SaveChanges();
        }

        public void Insert(Category category)
        {
            _object.Add(category);
            _context.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            _context.SaveChanges();
        }
    }
}

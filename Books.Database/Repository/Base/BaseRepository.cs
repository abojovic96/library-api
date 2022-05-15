using Books.Database.Models;
using Books.Database.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Repository.Base
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected void Add<T>(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Remove<T>(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}

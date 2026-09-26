using Melodify.DataAccessLayer.Abstract;
using Melodify.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MusicContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(MusicContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        } 

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();  
        }

        public async Task<T?> GetByIdAsync(int id)
        {
             return await _table.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }
    }
}

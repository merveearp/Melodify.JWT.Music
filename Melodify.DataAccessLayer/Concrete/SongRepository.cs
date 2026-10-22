using Melodify.DataAccessLayer.Abstract;
using Melodify.DataAccessLayer.Context;
using Melodify.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DataAccessLayer.Concrete
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(MusicContext context) : base(context)
        {
        }

        public async Task<List<Song>> GetAllWithDetailsAsync()
        {
            return await _table.AsNoTracking()
                .Include(x => x.Artist)
                .Include(x => x.Genre)
                .ToListAsync();
        }

        public async Task<Song?> GetByIdWithDetailsAsync(int id)
        {
            return await _table
                .AsNoTracking()
                .Include(x => x.Artist)
                .Include(x => x.Genre)
                .FirstOrDefaultAsync(x => x.SongId == id);
        }
    }
}


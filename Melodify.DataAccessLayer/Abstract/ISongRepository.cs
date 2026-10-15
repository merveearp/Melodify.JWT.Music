using Melodify.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DataAccessLayer.Abstract
{
    public interface ISongRepository :IGenericRepository<Song>
    {
        Task<List<Song>> GetAllWithDetailsAsync();
        Task<Song?> GetByIdWithDetailsAsync(int id);
    }
}

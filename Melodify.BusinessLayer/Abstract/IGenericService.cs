using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.BusinessLayer.Abstract
{
    public interface IGenericService<TResultDto,TCreateDto,TUpdateDto>
    {
        Task<List<TResultDto>> GetAllAsync();
        Task<TResultDto> GetByIdAsync(int id);

        Task CreateAsync(TCreateDto createDto);
        Task UpdateAsync(TUpdateDto updateDto);
        Task DeleteAsync(int id);
       
       
    }
}

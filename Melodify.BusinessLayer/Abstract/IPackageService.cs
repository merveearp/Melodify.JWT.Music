using Melodify.DtoLayer.PackagesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.BusinessLayer.Abstract
{
    public interface IPackageService
    {
        Task<List<ResultPackageDto>> GetAllAsync();
        Task<ResultPackageDto> GetByIdAsync(int id);
        Task UpdateAsync(UpdatePackageDto updateDto);
    }
}

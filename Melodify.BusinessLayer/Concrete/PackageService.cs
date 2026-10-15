using Mapster;
using Melodify.BusinessLayer.Abstract;
using Melodify.DataAccessLayer.Abstract;
using Melodify.DataAccessLayer.Concrete;
using Melodify.DataAccessLayer.Context;
using Melodify.DtoLayer.PackagesDtos;
using Melodify.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Melodify.BusinessLayer.Concrete
{
    public class PackageService : IPackageService
    {
        private readonly IGenericRepository<Package> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PackageService(IGenericRepository<Package> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ResultPackageDto>> GetAllAsync()
        {
            var valeus = await _genericRepository.GetAllAsync();
            return valeus.Adapt<List<ResultPackageDto>>();
        }

        public async Task<ResultPackageDto> GetByIdAsync(int id)
        {
            var value = await _genericRepository.GetByIdAsync(id);
            if(value is null)
            {
                throw new KeyNotFoundException("Seçtiğiniz paket bulunamadı");
            }
            return value.Adapt<ResultPackageDto>();
        }

        public async Task UpdateAsync(UpdatePackageDto updateDto)
        {
            var value = await _genericRepository.GetByIdAsync(updateDto.PackageId);
            if (value is null)
            {
                throw new KeyNotFoundException("Seçtiğiniz paket bulunamadı");
            }

            updateDto.Adapt(value);
            _genericRepository.Update(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

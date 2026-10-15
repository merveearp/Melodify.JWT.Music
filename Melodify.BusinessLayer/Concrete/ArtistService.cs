using Mapster;
using Melodify.BusinessLayer.Abstract;
using Melodify.DataAccessLayer.Abstract;
using Melodify.DtoLayer.ArtistDtos;
using Melodify.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.BusinessLayer.Concrete
{
    public class ArtistService : IArtistService
    {
        private readonly IGenericRepository<Artist> _artistRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IGenericRepository<Artist> artistRepository, IUnitOfWork unitOfWork)
        {
            _artistRepository = artistRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateArtistDto createDto)
        {
            var item = createDto.Adapt<Artist>();
            await _artistRepository.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item =await _artistRepository.GetByIdAsync(id);
            if(item is null)
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");

            }
             _artistRepository.Delete(item);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<List<ResultArtistDto>> GetAllAsync()
        {
            var items = await _artistRepository.GetAllAsync();
            return items.Adapt<List<ResultArtistDto>>();
        }

        public async Task<ResultArtistDto> GetByIdAsync(int id)
        {
           var item = await _artistRepository.GetByIdAsync(id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");
            }

            return item.Adapt<ResultArtistDto>();
        }

        public async Task UpdateAsync(UpdateArtistDto updateDto)
        {
           var item = await _artistRepository.GetByIdAsync(updateDto.ArtistId);
            if (item == null)
            {
                throw new KeyNotFoundException($"Artist with ID {updateDto.ArtistId} not found.");
            }

            updateDto.Adapt(item);
            _artistRepository.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

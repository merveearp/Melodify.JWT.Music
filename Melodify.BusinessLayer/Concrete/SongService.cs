using Mapster;
using Melodify.BusinessLayer.Abstract;
using Melodify.DataAccessLayer.Abstract;
using Melodify.DtoLayer.SongDtos;
using Melodify.EntityLayer.Entities;

namespace Melodify.BusinessLayer.Concrete
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SongService(ISongRepository songRepository, IUnitOfWork unitOfWork)
        {
            _songRepository = songRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateSongDto createDto)
        {
            var value = createDto.Adapt<Song>();
            await _songRepository.CreateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _songRepository.GetByIdAsync(id);
            if(value is null)
            {
                throw new KeyNotFoundException("Şarkı bulunamadı.");
            }

            _songRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultSongDto>> GetAllAsync()
        {
            var values = await _songRepository.GetAllWithDetailsAsync();
            return values.Adapt<List<ResultSongDto>>();
        }

        public async Task<ResultSongDto> GetByIdAsync(int id)
        {
            var value = await _songRepository.GetByIdWithDetailsAsync(id);

            if (value is null)
            {
                throw new KeyNotFoundException("Şarkı bulunamadı.");
            }
            return value.Adapt<ResultSongDto>();
        }

        public async Task UpdateAsync(UpdateSongDto updateDto)
        {
            var value = await _songRepository.GetByIdAsync(updateDto.SongId);
            if (value is null)
            {
                throw new KeyNotFoundException("Şarkı bulunamadı.");
            }

            updateDto.Adapt(value);
            _songRepository.Update(value);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}

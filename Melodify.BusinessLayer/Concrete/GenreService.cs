
using Mapster;
using Melodify.BusinessLayer.Abstract;
using Melodify.DataAccessLayer.Abstract;
using Melodify.DtoLayer.GenreDtos;
using Melodify.EntityLayer.Entities;

namespace Melodify.BusinessLayer.Concrete
{
    public class GenreService : IGenreService
    {
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IGenericRepository<Genre> genreRepository, IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateGenreDto createDto)
        {
            var item =createDto.Adapt<Genre>();
            await _genreRepository.CreateAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _genreRepository.GetByIdAsync(id);
            if (item is null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
            _genreRepository.Delete(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultGenreDto>> GetAllAsync()
        {
            var items = await _genreRepository.GetAllAsync();
            return items.Adapt<List<ResultGenreDto>>();


        }

        public async Task<ResultGenreDto> GetByIdAsync(int id)
        {
            var item = await _genreRepository.GetByIdAsync(id);
            if (item is null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
            return item.Adapt<ResultGenreDto>();

        }

        public async Task UpdateAsync(UpdateGenreDto updateDto)
        {

            var item = await _genreRepository.GetByIdAsync(updateDto.GenreId);

            if (item is null)
            {
                throw new KeyNotFoundException("Genre not found");
            }
            updateDto.Adapt(item);
            _genreRepository.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

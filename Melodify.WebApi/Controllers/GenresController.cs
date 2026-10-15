using Melodify.BusinessLayer.Abstract;
using Melodify.DtoLayer.GenreDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Melodify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _genreService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _genreService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateGenreDto createDto)
        {
            await _genreService.CreateAsync(createDto);

            return StatusCode(StatusCodes.Status201Created, "Müzik türü başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateGenreDto updateDto)
        {
            if(id != updateDto.GenreId)
            {
                return BadRequest("Müzik türü ID'si eşleşmiyor.");
            }
            await _genreService.UpdateAsync(updateDto);
            return Ok("Müzik türü başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genreService.DeleteAsync(id);
            return Ok("Müzik türü başarıyla silindi.");
        }

    }
}

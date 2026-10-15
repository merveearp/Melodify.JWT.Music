using Melodify.BusinessLayer.Abstract;
using Melodify.DtoLayer.SongDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Melodify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _songService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _songService.GetByIdAsync(id);
            return Ok(value);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSongDto createaDto)
        {
            await _songService.CreateAsync(createaDto);
            return StatusCode(StatusCodes.Status201Created, "Yeni şarkı başarıyla eklendi.");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSongDto updateDto)
        {
            if (id != updateDto.SongId)
            {
                return BadRequest("Şarkı ID'si eşleşmiyor.");
            }
            await _songService.UpdateAsync(updateDto);
            return Ok("Şarkı başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _songService.DeleteAsync(id);
            return Ok("Şarkı başarıyla silindi.");
        }
        
    }
}

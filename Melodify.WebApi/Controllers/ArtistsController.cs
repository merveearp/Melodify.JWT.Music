using Melodify.BusinessLayer.Abstract;
using Melodify.DtoLayer.ArtistDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Melodify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService; 

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _artistService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByıD(int id)
        {
            var value = await _artistService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateArtistDto createDto)
        {
            await _artistService.CreateAsync(createDto);
            return StatusCode(StatusCodes.Status201Created, "Sanatçı başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateArtistDto updateDto)
        {
            
            if(id != updateDto.ArtistId)
            {
                return BadRequest("Sanatçı bulunamadı.");
            }

            await _artistService.UpdateAsync(updateDto);
            return Ok("Sanatçı başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _artistService.DeleteAsync(id);
            return Ok("Sanatçı başarıyla silindi.");
        }

    }

    
}

using Melodify.BusinessLayer.Abstract;
using Melodify.DtoLayer.PackagesDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Melodify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _packageService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _packageService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdatePackageDto updateDto)
        {

            if (id != updateDto.PackageId)
            {
                return BadRequest("Paket ID'si eşleşmiyor.");
            }
            await _packageService.UpdateAsync(updateDto);
            return Ok("İlgili paket başarıyla güncellendi.");
        }

       
    }
}

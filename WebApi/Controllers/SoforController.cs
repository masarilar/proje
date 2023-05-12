using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Sofor;

namespace WebApi.Controllers
{
    public class SoforController : ApiControllerBase
    {
        private ISoforApp _soforApp { get; set; }
        public SoforController(ISoforApp soforApp)
        {
            _soforApp = soforApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SoforKaydet(DtoSoforKaydet model)
        {
            return Ok(await _soforApp.SoforKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SoforGuncelle(DtoSoforGuncelle model)
        {
            return Ok(await _soforApp.SoforGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SoforSil([FromBody] int id)
        {
            return Ok(await _soforApp.SoforSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SoforGetir([FromBody]int id)
        {
            return Ok(await _soforApp.SoforGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> SoforListesiGetir()
        {
            return Ok(await _soforApp.SoforListesiGetir());
        }
    }
}

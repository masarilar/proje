using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Arac;

namespace WebApi.Controllers
{
    public class AracController : ApiControllerBase
    {
        private IAracApp _aracApp { get; set; }
        public AracController(IAracApp aracApp)
        {
            _aracApp = aracApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracKaydet(DtoAracKaydet model)
        {
            return Ok(await _aracApp.AracKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracGuncelle(DtoAracGuncelle model)
        {
            return Ok(await _aracApp.AracGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracSil([FromBody] int id)
        {
            return Ok(await _aracApp.AracSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracGetir([FromBody] int id)
        {
            return Ok(await _aracApp.AracGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> AracListesiGetir()
        {
            return Ok(await _aracApp.AracListesiGetir());
        }

    }
}

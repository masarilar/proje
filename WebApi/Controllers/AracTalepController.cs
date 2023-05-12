using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.AracTalep;

namespace WebApi.Controllers
{
    public class AracTalepController : ApiControllerBase
    {
        private IAracTalepApp _aracTalepApp { get; set; }
        public AracTalepController(IAracTalepApp aracTalepApp)
        {
            _aracTalepApp = aracTalepApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTalepKaydet(DtoAracTalepKaydet model)
        {
            return Ok(await _aracTalepApp.AracTalepKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTalepGuncelle(DtoAracTalepGuncelle model)
        {
            return Ok(await _aracTalepApp.AracTalepGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTalepSil([FromBody] int id)
        {
            return Ok(await _aracTalepApp.AracTalepSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTalepGetir([FromBody] int id)
        {
            return Ok(await _aracTalepApp.AracTalepGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> AracTalepListesiGetir()
        {
            return Ok(await _aracTalepApp.AracTalepListesiGetir());
        }
    }
}

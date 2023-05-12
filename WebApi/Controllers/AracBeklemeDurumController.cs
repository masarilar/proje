using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.AracBeklemeDurum;

namespace WebApi.Controllers
{
    public class AracBeklemeDurumController : ApiControllerBase
    {
        private IAracBeklemeDurumApp _aracBeklemeDurumApp { get; set; }

        public AracBeklemeDurumController(IAracBeklemeDurumApp aracBeklemeDurumApp)
        {
            _aracBeklemeDurumApp = aracBeklemeDurumApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracBeklemeDurumKaydet(DtoAracBeklemeDurumKaydet model)
        {
            return Ok(await _aracBeklemeDurumApp.AracBeklemeDurumKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracBeklemeDurumGuncelle(DtoAracBeklemeDurumGuncelle model)
        {
            return Ok(await _aracBeklemeDurumApp.AracBeklemeDurumGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracBeklemeDurumSil([FromBody] int id)
        {
            return Ok(await _aracBeklemeDurumApp.AracBeklemeDurumSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracBeklemeDurumGetir([FromBody] int id)
        {
            return Ok(await _aracBeklemeDurumApp.AracBeklemeDurumGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> AracBeklemeDurumListesiGetir()
        {
            return Ok(await _aracBeklemeDurumApp.AracBeklemeDurumListesiGetir());
        }
    }
}
